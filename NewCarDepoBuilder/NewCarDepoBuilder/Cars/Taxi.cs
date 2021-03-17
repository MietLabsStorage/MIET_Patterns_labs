namespace NewCarDepoBuilder.Cars
{
    public class Taxi: Car
    {
        public bool ChildChairsExisting { get; set; } = false;
        
        /// <summary>
        /// capacity of passengers
        /// </summary>
        public override int Capacity => 4;
        
    }
}