using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Program_GSI
{
    class Point
    {
        static public int ii = 4;          //количество делений элемента
        static public int ij = 8;          //количество элементов
        public string[] name = new string[ii];
        public string[] goriz_Deg = new string[ii];
        public string[] vert_Deg = new string[ii];
        public string[] distation = new string[ii];
        public string[] coord_y = new string[ii];
        public string[] coord_x = new string[ii];
        public string[] coord_h = new string[ii];
        public string[] h_Vesh = new string[ii];
        public bool flag_error_point;

        private void Default()
        {
            if (name[3] == null)
                name = SetObject("11", "....", "+", "00000000");
            if (goriz_Deg[3] == null)
                goriz_Deg = SetObject("21", ".324", "+", "00000000");
            if (vert_Deg[3] == null)
                vert_Deg = SetObject("22", ".324", "+", "00000000");
            if (distation[3] == null)
                distation = SetObject("31", "...0", "+", "00000000");
            if (coord_y[3] == null)
                coord_y = SetObject("81", "...0", "+", "00000000");
            if (coord_x[3] == null)
                coord_x = SetObject("82", "...0", "+", "00000000");
            if (coord_h[3] == null)
                coord_h = SetObject("83", "...0", "+", "00000000");
            if (h_Vesh[3] == null)
                h_Vesh = SetObject("87", "...0", "+", "00000000");
        }

        private string[] SetObject(string id, string code, string sym, string data)
        {
            string[] mass = new string[ii];

            mass[0] = id;
            mass[1] = code;
            mass[2] = sym;
            mass[3] = data;

            return mass;
        }
        
        public static Point ReadStringGSI_toPoint(string openFile_string)
        {
            Point point = new Point();
            Regex code16 = new Regex(@"^[0-9.]{6}[+-]{1}[\S]{16}$");
            Regex code8 = new Regex(@"^[0-9.]{6}[+-]{1}[\S]{8}$");

            openFile_string = openFile_string.TrimStart('*');
            List<string> elements = new List<string>();
            elements.AddRange(openFile_string.Split(' '));

            string[] start_code = new string[] { "11", "21", "22", "31", "81", "82", "83", "87" };
            string[] elem = new string[start_code.Length];
            string[][] _base = new string[ij][];
            for (int i = 0; i < ij; i++)
            {
                _base[i] = new string[ii];
            }
            for (int i = 0; i < elem.Length; i++)
            {
                elem[i] = elements.Find(x => x.StartsWith(start_code[i]));
                if (elem[i] == null || (code8.IsMatch(elem[i]) || code16.IsMatch(elem[i])))
                {
                    if (!(elem[i] == null))
                    {
                        _base[i][0] = elem[i].Remove(2, elem[i].Length - 2);
                        _base[i][1] = elem[i].Remove(0, 2).Remove(4, elem[i].Remove(0, 2).Length - 4);
                        _base[i][2] = elem[i].Remove(0, 6).Remove(1, elem[i].Remove(0, 6).Length - 1);
                        if (code16.IsMatch(elem[i]))
                        {
                            _base[i][3] = elem[i].Remove(0, 15);
                        }
                        else
                        {
                            _base[i][3] = elem[i].Remove(0, 7);
                        }
                        point.flag_error_point = false;
                    }
                }
                else
                {
                    point.flag_error_point = true;
                }

            }

            for (int i = 0; i < ii; i++)
            {
                point.name[i] = _base[0][i];
                point.goriz_Deg[i] = _base[1][i];
                point.vert_Deg[i] = _base[2][i];
                point.distation[i] = _base[3][i];
                point.coord_y[i] = _base[4][i];
                point.coord_x[i] = _base[5][i];
                point.coord_h[i] = _base[6][i];
                point.h_Vesh[i] = _base[7][i];
            }
            point.Default();
            return point;
        }

        public static Point ReadString_Pcom_toPoint(string openFile_string)
        {
            Point point = new Point();
            Regex symb = new Regex(@"[.,]");
            Regex _double = new Regex(@"[,][0-9]{3}$");
            Regex to_gsi8 = new Regex(@"^[\S]{8}$");
            
            List<string> element = new List<string>();
            element.AddRange(openFile_string.Split(','));
            int end;

            string[] ch = new string[element.Count];
            
            for(int i = 1; i < element.Count; i++)
            {
                
                if (!symb.IsMatch(element[i]))
                    element[i] += ".";
                

                //element[i].Replace('.', ',');

                string tex_sym = "";
                foreach (char c in element[i])
                {
                    if (c == '.')
                        tex_sym += ',';
                    else
                        tex_sym += c;
                }
                element[i] = tex_sym;

                end = 0;
                while (!_double.IsMatch(element[i]) && end++ < 4)
                {
                    element[i] = $"{element[i]}0";
                }
                if (end > 3)
                    point.flag_error_point = true;
                
                //element[i].Replace(",", "");

                if (element[i].StartsWith("-"))
                {
                    element[i].TrimStart('-');
                    ch[i] = "-";
                }
                else
                    ch[i] = "+";


                string tex = "";
                foreach (char c in element[i])
                {
                    if (!(c == ','))
                        tex += c;
                }

                element[i] = tex;

            }

            for(int i = 0; i < element.Count; i++)
            {
                end = 0;
                while(!to_gsi8.IsMatch(element[i]) && end++ < 9)
                {
                    element[i] = $"0{element[i]}";
                }
                if (end > 8)
                    point.flag_error_point = true;
            }

            string[][] _base = new string[ij][];
            for (int i = 0; i < ij; i++)
            {
                _base[i] = new string[ii];
            }

            _base[0][0] = "11";
            _base[0][1] = "....";
            _base[0][2] = "+";
            _base[0][3] = element[0];

            _base[4][0] = "82";
            _base[4][1] = "...0";
            _base[4][2] = ch[1];
            _base[4][3] = element[1];

            _base[5][0] = "81";
            _base[5][1] = "...0";
            _base[5][2] = ch[2];
            _base[5][3] = element[2];

            _base[6][0] = "83";
            _base[6][1] = "...0";
            _base[6][2] = ch[3];
            _base[6][3] = element[3];


            for (int i = 0; i < ii; i++)
            {
                point.name[i] = _base[0][i];
                point.coord_x[i] = _base[4][i];
                point.coord_y[i] = _base[5][i];
                point.coord_h[i] = _base[6][i];
            }
            point.Default();
            return point;
        }

       

        #region old
        /*
        public void Enter(string str_point)
        {
            Regex data16 = new Regex(@"^[0-9A-Za-z]{16}$");

            List<string> elements_point = new List<string>();
            elements_point.AddRange(str_point.TrimStart('*').Split(' '));

            //elements_point.FindIndex(x => x.Remove(2, 14) == "11");
            int id_11 = elements_point.FindIndex(x => x.StartsWith("11"));
            int id_21 = elements_point.FindIndex(x => x.StartsWith("21"));
            int id_22 = elements_point.FindIndex(x => x.StartsWith("22"));
            int id_31 = elements_point.FindIndex(x => x.StartsWith("31"));
            int id_81 = elements_point.FindIndex(x => x.StartsWith("81"));
            int id_82 = elements_point.FindIndex(x => x.StartsWith("82"));
            int id_83 = elements_point.FindIndex(x => x.StartsWith("83"));
            int id_87 = elements_point.FindIndex(x => x.StartsWith("87"));


            if (id_11 != -1)
            {
                code_name = elements_point[id_11].Remove(2, elements_point[id_11].Length - 2);                   //13
                id_name = elements_point[id_11].Remove(0, 2).Remove(4, elements_point[id_11].Remove(0, 2).Length - 4);         //9
                sym_name = elements_point[id_11].Remove(0, 6).Remove(1, elements_point[id_11].Remove(0, 6).Length - 1);        //8
                name = elements_point[id_11].Remove(0, 7);

                if (data16.IsMatch(name))
                    name = name.Remove(0, 8);
            }

            if (id_21 != -1)
            {
                code_GorizDeg = elements_point[id_21].Remove(2, elements_point[id_21].Length - 2);
                id_GorizDeg = elements_point[id_21].Remove(0, 2).Remove(4, elements_point[id_21].Remove(0, 2).Length - 4);
                sym_GorizDeg = elements_point[id_21].Remove(0, 6).Remove(1, elements_point[id_21].Remove(0, 6).Length - 1);
                GorizDeg = elements_point[id_21].Remove(0, 7);

                if (data16.IsMatch(GorizDeg))
                    GorizDeg = GorizDeg.Remove(0, 8);
            }

            if (id_22 != -1)
            {
                code_VertDeg = elements_point[id_22].Remove(2, elements_point[id_22].Length - 2);
                id_VertDeg = elements_point[id_22].Remove(0, 2).Remove(4, elements_point[id_22].Remove(0, 2).Length - 4);
                sym_VertDeg = elements_point[id_22].Remove(0, 6).Remove(1, elements_point[id_22].Remove(0, 6).Length - 1);
                VertDeg = elements_point[id_22].Remove(0, 7);

                if (data16.IsMatch(VertDeg))
                    VertDeg = VertDeg.Remove(0, 8);
            }

            if (id_31 != -1)
            {
                code_Distation = elements_point[id_31].Remove(2, elements_point[id_31].Length - 2);
                id_Distation = elements_point[id_31].Remove(0, 2).Remove(4, elements_point[id_31].Remove(0, 2).Length - 4);
                sym_Distation = elements_point[id_31].Remove(0, 6).Remove(1, elements_point[id_31].Remove(0, 6).Length - 1);
                Distation = elements_point[id_31].Remove(0, 7);

                if (data16.IsMatch(Distation))
                    Distation = Distation.Remove(0, 8);
            }

            if (id_81 != -1)
            {
                code_Y = elements_point[id_81].Remove(2, elements_point[id_81].Length - 2);
                id_Y = elements_point[id_81].Remove(0, 2).Remove(4, elements_point[id_81].Remove(0, 2).Length - 4);
                sym_Y = elements_point[id_81].Remove(0, 6).Remove(1, elements_point[id_81].Remove(0, 6).Length - 1);
                Y = elements_point[id_81].Remove(0, 7);

                if (data16.IsMatch(Y))
                    Y = Y.Remove(0, 8);
            }

            if (id_82 != -1)
            {
                code_X = elements_point[id_82].Remove(2, elements_point[id_82].Length - 2);
                id_X = elements_point[id_82].Remove(0, 2).Remove(4, elements_point[id_82].Remove(0, 2).Length - 4);
                sym_X = elements_point[id_82].Remove(0, 6).Remove(1, elements_point[id_82].Remove(0, 6).Length - 1);
                X = elements_point[id_82].Remove(0, 7);

                if (data16.IsMatch(X))
                    X = X.Remove(0, 8);
            }

            if (id_83 != -1)
            {
                code_H = elements_point[id_83].Remove(2, elements_point[id_83].Length - 2);
                id_H = elements_point[id_83].Remove(0, 2).Remove(4, elements_point[id_83].Remove(0, 2).Length - 4);
                sym_H = elements_point[id_83].Remove(0, 6).Remove(1, elements_point[id_83].Remove(0, 6).Length - 1);
                H = elements_point[id_83].Remove(0, 7);

                if (data16.IsMatch(H))
                    H = H.Remove(0, 8);
            }

            if (id_87 != -1)
            {
                code_hVesh = elements_point[id_87].Remove(2, elements_point[id_87].Length - 2);
                id_hVesh = elements_point[id_87].Remove(0, 2).Remove(4, elements_point[id_87].Remove(0, 2).Length - 4);
                sym_hVesh = elements_point[id_87].Remove(0, 6).Remove(1, elements_point[id_87].Remove(0, 6).Length - 1);
                hVesh = elements_point[id_87].Remove(0, 7);

                if (data16.IsMatch(hVesh))
                    hVesh = hVesh.Remove(0, 8);
            }
        }
        */
        #endregion

    }
}
