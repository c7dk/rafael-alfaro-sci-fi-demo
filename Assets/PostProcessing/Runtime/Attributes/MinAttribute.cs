namespace UnityEngine.PostProcessing
{
    public sealed class MinAttribute2 : PropertyAttribute
    {
        public float min;

        public void MinAttribute(float min)
        {
            this.min = min;
        }
    }
}
