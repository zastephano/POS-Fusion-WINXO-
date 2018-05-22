using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
//xml node
using System.Xml;
//streamwriter
using System.IO;
//IPAdress && IPEndPoint
using System.Net;
//class soket
using System.Net.Sockets;

namespace POS_Fusion
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SqlConnection cn = new SqlConnection(@"Data Source=172.16.23.223;Network Library=DBMSSOCN;Initial Catalog=Win_Fusion;User ID=winfusion;Password=winfusion2016");
        public static SqlDataAdapter da = new SqlDataAdapter();
        public static DataSet ds = new DataSet();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter da1 = new SqlDataAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Open) { cn.Close(); }
                cn.Open();
                da = new SqlDataAdapter("select LibelleStation,AdresseIP from Station1 where (FLAG_SUPP is null or FLAG_SUPP=0) and FDC=1", cn);
                da.Fill(ds, "station1");
                list1.DataSource = ds.Tables["station1"];
                list1.DisplayMember = "LibelleStation";
                list1.ValueMember = "AdresseIP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème de connexion !");
            }
        } 

        public static void SendRequest(ListBox lb,string chemin)
        {
            //Déclaration
            int value;
            string RequestId, OverallResult, RequestType;
            byte[] data;
            byte[] byte2;
            byte[] header;
            byte[] footer;
            int bytes;
            string libelle;
            string responseData;
            string device_id;
            string code;
            string DeviceState;
            string animateur;
            Socket sender;
            IPAddress ipAddress;
            IPEndPoint remoteEP;
            //--------------------------

            //--------------------------------------------------------------------------//
            //--------------------------------------------------------------------------//
            //-----------------Send Query (LogOn) for make a connection------------------//
            //--------------------------------------------------------------------------//
            //--------------------------------------------------------------------------//

            string val1 = "Exceptions_etat_totem_ " + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            //string test1 = @"C:\Users\STEPHANO\Desktop\dosdeconnecté";
            FileInfo fichier = new FileInfo(chemin + val1 + ".txt");
            StreamWriter sw1 = new StreamWriter(chemin + val1 + ".txt", true, System.Text.Encoding.ASCII);
            sw1.WriteLine("Station \t Exception");

            string val2 = "Etat_totem_ " + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            FileInfo fichier1 = new FileInfo(chemin + val2 + ".txt");
            StreamWriter sw2 = new StreamWriter(chemin + val2 + ".txt", true, System.Text.Encoding.ASCII);
            sw2.WriteLine("Code station \t Station \t Animateur/Superviseur \t Adresse IP \t Totem \t Etat totem \t Date");


            //boucler sur la liste des stations sélectionnées
            for (int i = 0; i < lb.Items.Count; i++)
            {

                //get libellestation and adressIP from database
                libelle = ((DataRowView)lb.Items[i])["LibelleStation"].ToString();
                ipAddress = IPAddress.Parse(((DataRowView)lb.Items[i])["AdresseIP"].ToString());

                //création de l'objet de connexion
                sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //instanciation de IPEndPoint
                //4710 ==> le port
                remoteEP = new IPEndPoint(ipAddress, 4710);

                try
                {
                    sender.Connect(remoteEP);
                    data = Encoding.ASCII.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\" ?> \n<ServiceRequest xmlns:xsi=\"<http://www.w3.org/2001/XMLSchema-instance>\" xmlns:xsd=\"<http://www.w3.org/2001/XMLSchema>\" RequestType=\"LogOn\" ApplicationSender=\"maan.\" WorkstationID=\"MXP1-BRP\" RequestID=\"1\"> \n<POSdata> \n<POSTimeStamp>2016-11-24T14:36:23</POSTimeStamp> \n<InterfaceVersion>01.00</InterfaceVersion> \n</POSdata> \n</ServiceRequest>");
                    value = data.Length;
                    byte2 = BitConverter.GetBytes(value);

                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(byte2);
                    header = new byte[6];
                    header[0] = byte2[0];
                    header[1] = byte2[1];
                    header[2] = byte2[2];
                    header[3] = byte2[3];
                    header[4] = 0;
                    header[5] = 0;

                    sender.Send(header);

                    sender.Send(data);

                    footer = new byte[2];
                    footer[0] = Convert.ToByte("0");
                    footer[1] = Convert.ToByte("0");
                    sender.Send(footer);


                    //--------------------------------------------------------------------------//
                    //--------------------------------------------------------------------------//
                    //-----------------Receive Answer(LogOn) for make a connection---------------//
                    //--------------------------------------------------------------------------//
                    //--------------------------------------------------------------------------//

                    RequestType = "";
                    RequestId = "";
                    OverallResult = "";
                    responseData = "";
                    bytes = 0;

                    XmlDocument doc = new XmlDocument();
                    XmlNodeList nodes;

                    do
                    {
                        data = new Byte[20000];
                        bytes = sender.Receive(data);

                        if (bytes != 0)
                        {
                           // data => la reponse & 6 => le debut & bytes - 6 => count   car on peut recevoir une reponse qui debute avec des caractere inutile pour nous
                            responseData = Encoding.ASCII.GetString(data, 6, (bytes - 6));

                            try
                            {
                                doc.LoadXml(responseData);
                                nodes = doc.DocumentElement.SelectNodes("/ServiceResponse");
                                RequestType = nodes[0].Attributes["RequestType"].InnerText;
                                RequestId = nodes[0].Attributes["RequestID"].InnerText;
                                OverallResult = nodes[0].Attributes["OverallResult"].InnerText;
                            }
                            catch { }
                        }
                    }
                    while (RequestId != "1");

                    //---------------------------------------------------------------------------------------//
                    //-----------------------------reSend Query(Afficheur TOTEM)------------------------------//
                    //---------------------------------------------------------------------------------------//

                    if (OverallResult == "Success")
                    {
                        data = Encoding.ASCII.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\" ?> <ServiceRequest RequestType=\"GetPPState\" ApplicationSender=\"maan.\" WorkstationID=\"MXP1-BRP\" RequestID=\"2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"FDC_GetPPState_Request.xsd\"> <POSdata> <POSTimeStamp>2009-11-20T17:30:50</POSTimeStamp> <DeviceClass Type=\"PP\" DeviceID=\"*\"/> </POSdata> </ServiceRequest>");
                        //data = Encoding.ASCII.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\" ?> <ServiceRequest RequestType=\"GetPPConfiguration\" ApplicationSender=\"maan.\" WorkstationID=\"MXP1-BRP\" RequestID=\"01254\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"FDC_GetPPConfiguration_Request.xsd\"> <POSdata> <POSTimeStamp>2009-11-20T17:30:50</POSTimeStamp> </POSdata> </ServiceRequest>");
                        value = data.Length;
                        byte2 = BitConverter.GetBytes(value);
                        Console.WriteLine(BitConverter.ToString(byte2));

                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(byte2);
                        header = new byte[6];
                        header[0] = byte2[0];
                        header[1] = byte2[1];
                        header[2] = byte2[2];
                        header[3] = byte2[3];
                        header[4] = 0;
                        header[5] = 0;

                        sender.Send(header);
                        sender.Send(data);

                        footer = new byte[2];
                        footer[0] = Convert.ToByte("0");
                        footer[1] = Convert.ToByte("0");
                        sender.Send(footer);

                        //---------------------------------------------------------------------------//
                        //-------------------------------------------------------------------------- //
                        //---------------------Receive Answer (Afficheur TOTEM)-----------------------//
                        //---------------------------------------------------------------------------//
                        //---------------------------------------------------------------------------//
                        
                        do
                        {
                            data = new Byte[20000];
                            bytes = 0;
                            bytes = sender.Receive(data);
                            if (bytes != 0)
                            {
                                responseData = Encoding.ASCII.GetString(data, 6, (bytes - 6));

                                try
                                {
                                    doc.LoadXml(responseData);
                                    nodes = doc.DocumentElement.SelectNodes("/ServiceResponse");
                                    RequestId = nodes[0].Attributes["RequestID"].InnerText;
                                    OverallResult = nodes[0].Attributes["OverallResult"].InnerText;
                                    RequestType = nodes[0].Attributes["RequestType"].InnerText;
                                }
                                catch (Exception e) { }
                            }
                        }
                        while (RequestId != "2");
                        if (OverallResult == "Success")
                        {
                            device_id = "";
                            code = "";
                            DeviceState = "";
                            animateur = "";

                            try
                            {

                                XmlNodeList my_nodes = doc.DocumentElement.SelectNodes("/ServiceResponse/FDCdata");

                                //objet va se charger dans node-nv1
                                foreach (XmlNode node_nv1 in my_nodes[0].ChildNodes)
                                {
                                    if (node_nv1.Name == "DeviceClass")
                                    {
                                        //device_id pour l'ecrire dans le fichier de resultat
                                        device_id = node_nv1.Attributes["DeviceID"].InnerText;

                                        foreach (XmlNode node_nv2 in node_nv1.ChildNodes)
                                        {

                                            if (node_nv2.Name == "DeviceState")
                                            {
                                                //Etat du totem
                                                DeviceState = node_nv2.InnerText;

                                                //l'etat des paneaux s'il est connecter aux boitier
                                                if (DeviceState != "FDC_READY")
                                                {
                                                    //recupere code headoffice et animateur
                                                    try
                                                    {
                                                        code = get_code_SAP(ipAddress.ToString());
                                                        animateur = animateur_superviseur(ipAddress.ToString());
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        sw1.WriteLine(libelle + "\t" + e.Message);
                                                    }

                                                    //libelle / pump_id / nozzle_id / device_state/date
                                                    sw2.Write(code + "\t" + libelle + "\t" + animateur + "\t" + ipAddress.ToString() + "\t" + device_id + "\t" + DeviceState + "\t" + DateTime.Now.ToString());
                                                    sw2.WriteLine("\n");
                                                }
                                            }
                                        }
                                    }
                                }


                            }
                            catch (Exception e)
                            {
                                sw1.WriteLine(libelle + "\t" + e.Message);
                            }
                        }
                        else { }
                    }//fin if (verification loggon)
                    else
                    {
                        sw1.WriteLine(libelle + "\t Loggon Failed");
                    }
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (Exception e)
                {
                    sw1.WriteLine(libelle + "\t" + e.Message);
                }
            }//fermeture boucle des stations

            sw1.Close();
            sw2.Close();
        }

        public static string get_code_SAP(string adresseIp)
        {
          
            if (cn.State == ConnectionState.Closed)
            {
                cn.ConnectionString = "Data Source=172.16.23.223;Network Library=DBMSSOCN;Initial Catalog=Win_Fusion;User ID=winfusion;Password=winfusion2016";

                try
                {
                    cn.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            try
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select SiteNumber from Station1 where (FLAG_SUPP is null or FLAG_SUPP=0) and FDC = 1 and AdresseIP='" + adresseIp + "'";
                da1.SelectCommand = cmd;
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string animateur_superviseur(string adresse_ip) 
        {
            if (cn.State == ConnectionState.Closed)
            {
                //sqlcon.ConnectionString = "Data Source=MOUAD-PC;Initial Catalog=Win_Fusion;Integrated Security=True";
                cn.ConnectionString = "Data Source=172.16.23.223;Network Library=DBMSSOCN;Initial Catalog=Win_Fusion;User ID=winfusion;Password=winfusion2016";
                try
                {
                    cn.Open();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }

            try
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select nom+' '+prenom from animateur_superviseur,Station1 where id_animateur=animateur_superviseur.Id and AdresseIP='" + adresse_ip + "'";
                da1.SelectCommand = cmd;
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void move_all_right_Click(object sender, EventArgs e)
        {
            bool tr = false;
            for (int i = 0; i < list1.Items.Count; i++)
            {
                for (int j = 0; j < list2.Items.Count; j++)
                {
                    if (list1.Items[i] == list2.Items[j])
                    {
                        tr = true;
                    }
                }

                if (!tr)
                {
                    list2.DisplayMember = list1.DisplayMember;
                    list2.ValueMember = list1.ValueMember;
                    list2.Items.Add(list1.Items[i]);
                }
                tr = false;
            }
        }

        private void move_one_right_Click(object sender, EventArgs e)
        {
            bool tr = false;
            for (int i = 0; i < list1.SelectedItems.Count; i++)
            {
                for (int j = 0; j < list2.Items.Count; j++)//comparer chaque item de lb_tous_stations par items de lb_stations_select
                {
                    if (list1.SelectedItems[i] == list2.Items[j])
                    {
                        tr = true;//item trouvé (deja existe dans lb_stations_select)
                    }
                }

                if (!tr)
                {
                    list2.DisplayMember = list1.DisplayMember;
                    list2.ValueMember = list1.ValueMember;
                    list2.Items.Add(list1.SelectedItems[i]);
                }
                tr = false;
            }
        }

        private void move_one_left_Click(object sender, EventArgs e)
        {
            list2.Items.Remove(list2.SelectedItem);
        }

        private void move_all_left_Click(object sender, EventArgs e)
        {
            list2.Items.Clear();
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (Directory.Exists(txtpath.Text) == true)
            {
                SendRequest(list2, txtpath.Text);
            }
            else
            {
                MessageBox.Show("Chemin invalid !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Opération terminée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
