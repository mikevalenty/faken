using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FakeN.Web {
	public static class HttpObjectExtensions {
		public static FakeHttpResponse Set<T>(this FakeHttpResponse res, Expression<Func<FakeHttpResponse, T>> getterExpression, T value) {
			res.Set<FakeHttpResponse, T>(getterExpression, value);
			return res;
		}

		public static FakeHttpRequest Set<T>(this FakeHttpRequest req, Expression<Func<FakeHttpRequest, T>> getterExpression, T value) {
			req.Set<FakeHttpRequest, T>(getterExpression, value);
			return req;
		}

		public static FakeHttpSessionState Set<T>(this FakeHttpSessionState session, Expression<Func<FakeHttpSessionState, T>> getterExpression, T value) {
			session.Set<FakeHttpSessionState, T>(getterExpression, value);
			return session;
		}

		public static FakeHttpContext Set<T>(this FakeHttpContext context, Expression<Func<FakeHttpContext, T>> getterExpression, T value) {
			context.Set<FakeHttpContext, T>(getterExpression, value);
			return context;
		}

		public static FakeHttpCachePolicy Set<T>(this FakeHttpCachePolicy cache, Expression<Func<FakeHttpCachePolicy, T>> getterExpression, T value) {
			cache.Set<FakeHttpCachePolicy, T>(getterExpression, value);
			return cache;
		}

		private static void Set<T, TValue>(this T req, Expression<Func<T, TValue>> getterExpression, TValue value) {
			var body = getterExpression.Body as MemberExpression;
			if (body == null) {
				throw new ArgumentException("Expression is not a get accessor", "getterExpression");
			}

			var member = body.Member;

			//call set method if it exists
			var setMethod = req.GetType().GetMethod("Set" + member.Name, new[] { typeof(T) });
			if (setMethod != null) {
				setMethod.Invoke(req, new object[] { value });
				return;
			}

			//otherwise fall back to private backing field
			var backingField = member.Name.Substring(0, 1).ToLower() + member.Name.Substring(1);
			var field = req.GetType().GetField(backingField, BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null) {
				throw new Exception(string.Format("The backing field {0} for {1} doesn't exist", backingField, member.Name));
			}

			field.SetValue(req, value);
		}
	}
}