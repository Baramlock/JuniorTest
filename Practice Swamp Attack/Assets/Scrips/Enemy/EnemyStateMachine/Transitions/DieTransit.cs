     public class DieTransit : Transition
    {
        private void Update()
        {
            if (Target == null)
            {
                NeedTransit = true;
            }
        }
    }
