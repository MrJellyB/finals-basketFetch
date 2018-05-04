using System;

namespace Basket.Common.Attribute
{
    public abstract class BaseCritieria : System.Attribute, ICriteria
    {

        #region Data Members



        #endregion

        #region Methods

        public abstract float Calculate();

        #endregion
    }
}
