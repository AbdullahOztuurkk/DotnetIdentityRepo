using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace CourseWebUI.Core.Aspects.Postsharp.Transaction
{
    [Serializable]
    public class TransactionAspect:OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;

        public TransactionAspect()
        {
                
        }
        public TransactionAspect(TransactionScopeOption transactionScope)
        {
            _option = transactionScope;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope) args.MethodExecutionTag).Complete();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope) args.MethodExecutionTag).Dispose();
        }
    }
}
