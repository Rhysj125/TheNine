using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Standard_Assets
{
    public interface IDamageable
    {
        void TakeDamage(int damage);
        void Destory();
    }
}
