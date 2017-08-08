using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoDCollectables.Collectors
{
    /// <summary>
    /// Represents a collectable collection
    /// </summary>
    public interface ICollectableCollection
    {
        /// <summary>
        /// Peeks the first time
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the queue</returns>
        Collectable Peek();

        /// <summary>
        /// Pops the first item
        /// </summary>
        /// <returns>the top <see cref="Collectable"/> on the queue</returns>
        Collectable Pop();

        /// <summary>
        /// Enumerable collection of items in the stack
        /// </summary>
        IEnumerable<Collectable> Items
        {
            get;
        }
    }
}
