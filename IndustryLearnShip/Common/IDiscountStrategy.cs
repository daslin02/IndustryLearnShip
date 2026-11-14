using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Common
{
    /// <summary>
    /// Defines a strategy for applying a discount to a price.
    /// </summary>
    public interface IDiscountStrategy
    {
        /// <summary>
        /// Applies the discount to the specified price and returns the final price.
        /// </summary>
        decimal Apply(decimal price);

        /// <summary>
        /// Returns a human-readable description of the strategy.
        /// </summary>
        string Description { get; }
    }
}
