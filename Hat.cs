namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription
        {
            get
            {
                string Shine = "intial";

                if (ShininessLevel < 2)
                {
                    Shine = "dull";
                }
                else if (ShininessLevel >= 2 && ShininessLevel <= 5)
                {
                    Shine = "noticeable";
                }
                else if (ShininessLevel >= 6 && ShininessLevel <= 9)
                {
                    Shine = "bright";
                }
                else if (ShininessLevel > 9)
                {
                    Shine = "blinding";
                }

                return Shine;
            }
        }
    }
}