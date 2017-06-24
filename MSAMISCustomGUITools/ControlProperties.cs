using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISCustomGUITools {
    public class ControlProperties {

        //Buttons
        public class Button {
            public static System.Drawing.Point Left = new System.Drawing.Point(112, 165);
            public static System.Drawing.Point Right = new System.Drawing.Point(264, 165);
            public static System.Drawing.Point Center = new System.Drawing.Point(112, 165);

            public static System.Drawing.Point FarLeft = new System.Drawing.Point(35, 165);
            public static System.Drawing.Point FarRight = new System.Drawing.Point(289, 165);
            public static System.Drawing.Point Middle = new System.Drawing.Point(162, 165);
        }

        public class Text {
            public class WithIcon {
                public static System.Drawing.Size Size = new System.Drawing.Size(292, 141);
                public static System.Drawing.Point Location = new System.Drawing.Point(112, 15);
            }
            public class WithoutIcon {
                public static System.Drawing.Size Size = new System.Drawing.Size(388, 141);
                public static System.Drawing.Point Location = new System.Drawing.Point(16, 15);
                
            }
        }
    }
}
