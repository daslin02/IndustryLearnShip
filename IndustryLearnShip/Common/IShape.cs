using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Common
{
    using System;

    namespace IndustryLearnShip.Models
    {
        /// <summary>
        /// Interface for geometric shapes.
        /// </summary>
        public interface IShape
        {
            /// <summary>
            /// Calculates the area of the shape.
            /// </summary>
            double Area();

            /// <summary>
            /// Calculates the perimeter of the shape.
            /// </summary>
            double Perimeter();

            /// <summary>
            /// Returns a human-readable description of the shape.
            /// </summary>
            string Description { get; }
        }
    }
}
