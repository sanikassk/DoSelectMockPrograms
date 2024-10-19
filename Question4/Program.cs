namespace Question4
{
    public interface IBroadbandPlan
    {
        int GetBroadbandPlanAmount();
    }


    public class Black : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;

        public Black(bool isSubscriptionValid, int discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 50.");
            }

            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
        }

        public int GetBroadbandPlanAmount()
        {
            return _isSubscriptionValid ? (int)(PlanAmount - (PlanAmount * _discountPercentage / 100.0)) : PlanAmount;
        }
    }


    public class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;

        public Gold(bool isSubscriptionValid, int discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 30.");
            }

            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
        }

        public int GetBroadbandPlanAmount()
        {
            return _isSubscriptionValid ? (int)(PlanAmount - (PlanAmount * _discountPercentage / 100.0)) : PlanAmount;
        }
    }


    public class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;

        public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
        {
            if (broadbandPlans == null)
            {
                throw new ArgumentNullException(nameof(broadbandPlans));
            }

            _broadbandPlans = broadbandPlans;
        }

        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            if (_broadbandPlans == null)
            {
                throw new ArgumentNullException(nameof(_broadbandPlans));
            }

            var subscriptionPlans = new List<Tuple<string, int>>();

            foreach (var plan in _broadbandPlans)
            {
                string planType = plan.GetType().Name;
                int amount = plan.GetBroadbandPlanAmount();

                subscriptionPlans.Add(Tuple.Create(planType, amount));
            }

            return subscriptionPlans;
        }
    }

    class Program
    {
        static void Main()
        {
            var plans = new List<IBroadbandPlan>
    {
        new Black(true, 50),
        new Black(false, 10),
        new Gold(true, 30),
        new Black(true, 20),
        new Gold(false, 20)
    };

            var subscriptionPlans = new SubscribePlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Item1}, {item.Item2}");
            }
        }
    }

}
