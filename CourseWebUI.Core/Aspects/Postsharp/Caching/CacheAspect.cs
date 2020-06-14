using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CourseWebUI.Core.CrossCuttingCorners.Caching;
using PostSharp.Aspects;

namespace CourseWebUI.Core.Aspects.Postsharp.Caching
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cachingType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type cachingType, int cacheByMinute=60)
        {
            _cachingType = cachingType;
            _cacheByMinute = cacheByMinute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_cachingType.BaseType.IsAssignableFrom(typeof(ICacheManager)) == false)
                throw new Exception("Wrong Cache Type !");

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cachingType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var MethodName = String.Format("{0}.{1}.{2}", 
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name, 
                args.Method.Name);

            var arguments = args.Arguments.ToList();

            var key = string.Format("{0}.{1}", MethodName,
                String.Join(",", arguments).Select(z => z != null ? z.ToString() : "<Null>"));

            if (_cacheManager.IsAdd(key))
                args.ReturnValue = _cacheManager.Get<Object>(key);
            base.OnInvoke(args);
            _cacheManager.Add(key,args.ReturnValue,_cacheByMinute);
        }
    }
}
