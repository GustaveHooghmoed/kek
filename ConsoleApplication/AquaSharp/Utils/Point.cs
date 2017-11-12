using System.Security.Cryptography.X509Certificates;

namespace ConsoleApplication.AquaSharp.Utils
{
    public class Point
    {
        public string id;
        public string x;
        public string y;
        public string z;
        public string yaw;

        public Point(string id, string s, string s1, string s2, string yaw)
        {
            this.id = id;
            this.x = s;
            this.y = s1;
            this.z = s2;
            this.yaw = yaw;
        }
    }
}