using System;

namespace Rent_Me_Inventory_Management_Solutions.View.User_Controls
{
    /// <summary>
    ///     This class was created to fix a VS-problem which doesn't allow the Designer to work with inherited abstract
    ///     classes. Do not instantiate!
    /// </summary>
    public class BSMiddleClass : RentMeUserControl
    {
        /// <summary>
        /// Processes the child element in the parent class.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void processChild()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Processes the parameters.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void processParentIntention()
        {
            throw new NotImplementedException();
        }
    }
}