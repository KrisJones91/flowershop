namespace flowershop.Models
{
    public class FlowBo
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public int BoquetId { get; set; }
    }

    public class FlowBoViewModel : Flower
    {
        public int FlowBowId { get; set; }
    }
}