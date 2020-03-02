using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Program_GSI
{
    class Points_List
    {
        public static bool delete_null;
        public static bool delete_repeat;
        public List<Point> poits_list = new List<Point>();
        public bool Open_File_Points(string adress)
        {
            bool _Ok = true;
            List<Point> _add_list = new List<Point>();
            Regex gsi = new Regex(@"\*{0,1}11[0-9.]{4}[+-]{1}\S{8,16}");
            Regex pcom = new Regex(@"^\S{1,},(-){0,1}\d{1,}(.){0,1}\d{0,3},(-){0,1}\d{1,}(.){0,1}\d{0,3},(-){0,1}\d{1,}(.){0,1}\d{0,3}$");
            //Points_List points = new Points_List();


            List<string> open_file = new List<string>();
            open_file.AddRange(File.ReadAllLines(adress));


            if (open_file.All(x => gsi.IsMatch(x)) || open_file.All(x => pcom.IsMatch(x)))
            {
                for (int i = 0; i < open_file.Count; i++)
                {
                    Point p = new Point();
                    if(open_file.All(x => gsi.IsMatch(x)))
                    {
                        p = Point.ReadStringGSI_toPoint(open_file[i]);
                        _add_list.Add(p);
                        if (p.flag_error_point)
                            _Ok = false;
                    }

                    if (open_file.All(x => pcom.IsMatch(x)))
                    {
                        p = Point.ReadString_Pcom_toPoint(open_file[i]);
                        _add_list.Add(p);
                        if (p.flag_error_point)
                            _Ok = false;
                    }
                }
            }
            else
            {
                _Ok = false;
            }
            if (_Ok)
                poits_list.AddRange(_add_list);

            return _Ok;
        }

        public void Save_GSI_fix(string adress)
        {
            //bool _Ok = true;
            List<Point> save = new List<Point>();

            if (delete_null)

                save = Delete_null(poits_list);
            else
                save = poits_list;

            if (delete_repeat)
                save = Delete_repeat(save);
            
            List<string> save_file = new List<string>();
            
            for (int i = 0; i < save.Count; i++)
            {
                string name = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    name += $"{save[i].name[j]}";
                }
                string Y = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    Y += $"{save[i].coord_y[j]}";
                }
                string X = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    X += $"{save[i].coord_x[j]}";
                }
                string H = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    H += $"{save[i].coord_h[j]}";
                }



                save_file.Add($"{name} {Y} {X} {H} ");
            }
            
            File.WriteAllLines(adress, save_file.ToArray());
        }


        public void Save_GSI_Meas(string adress)
        {
            //bool _Ok = true;
            List<Point> save = new List<Point>();

            if (Points_List.delete_null)
                save = Delete_null(poits_list);
            else
                save = poits_list;

            if (Points_List.delete_repeat)
                save = Delete_repeat(save);

            List<string> save_file = new List<string>();
            string nspace = "";
            for (int n = 0; n < 49; n++)
                nspace += " ";

            for (int i = 0; i < save.Count; i++)
            {
                string name = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    name += $"{save[i].name[j]}";
                }
                string goriz_Deg = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    goriz_Deg += $"{save[i].goriz_Deg[j]}";
                }
                string vert_Deg = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    vert_Deg += $"{save[i].vert_Deg[j]}";
                }
                string distation = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    distation += $"{save[i].distation[j]}";
                }
                string Y = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    Y += $"{save[i].coord_y[j]}";
                }
                string X = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    X += $"{save[i].coord_x[j]}";
                }
                string H = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    H += $"{save[i].coord_h[j]}";
                }
                string h_Vesh = "";
                for (int j = 0; j < Point.ii; j++)
                {
                    h_Vesh += $"{save[i].h_Vesh[j]}";
                }



                save_file.Add($"{name} {goriz_Deg} {vert_Deg} {distation} {Y} {X} {H} {h_Vesh} ");
            }

            File.WriteAllLines(adress, save_file.ToArray());
        }

        public List<Point> Delete_null (List<Point> list)
        {
            List<Point> list_null = new List<Point>(list);
            if (delete_null)
            {
                for (int i = 0; i < list_null.Count; i++)
                {
                    if (Convert.ToInt32(list_null[i].coord_x[3]) == 0 && Convert.ToInt32(list_null[i].coord_y[3]) == 0 && Convert.ToInt32(list_null[i].coord_h[3]) == 0)
                    {
                        list_null.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
                list_null = list;
            return list_null;
        }

        public List<Point> Delete_repeat (List<Point> list)
        {
            List<Point> list_rep = new List<Point>(list);
            if (delete_repeat)
            {
                for (int i = 0; i < list_rep.Count; i++)                //положение первой точки одного наименования
                {
                    for (int j = i + 1; j < list_rep.Count; j++)        //далее точки по списку
                    {
                        if (list_rep[j].name[3] == list_rep[i].name[3])
                        {
                            list_rep.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
            else
                list_rep = list;
            return list_rep;
        }
    }
}
