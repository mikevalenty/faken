using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Web;

namespace FakeN.Web
{
	public class FakeHttpFileCollection : HttpFileCollectionBase
	{
		private readonly CaseInsensitiveNameObjectCollection collection;

		public FakeHttpFileCollection()
		{
			// It would be desirable for this class to use the behavior it inherits from NameObjectCollectionBase 
			// through HttpFileCollectionBase, however that won't work because HttpFileCollectionBase overrides 
			// most of the desired behavior by throwing NotImplementedExceptions instead.
			// HttpFileCollectionBase also fails to initialize the NameObjectCollectionBase with a case-
			// insensitive key-comparer the way the real HttpFileCollection does.

			// Therefore we are aggregating a custom NameObjectCollectionBase implementation instead of using the one we inherit.
			collection = new CaseInsensitiveNameObjectCollection();
		}

		public void Add(string formFieldValue, FakeHttpPostedFile file)
		{
			collection.Add(formFieldValue, file);
		}

		/// <summary>
		/// Copies the elements of the collection to an array, starting at the specified index in the array.
		/// </summary>
		/// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param><param name="index">The zero-based index in <paramref name="array"/> at which copying starts.</param><exception cref="T:System.NotImplementedException">Always.</exception>
		public override void CopyTo(Array array, int index)
		{
			((ICollection)collection).CopyTo(array, index);
		}

		/// <summary>
		/// Returns the posted file object at the specified index.
		/// </summary>
		/// <returns>
		/// The posted file object specified by <paramref name="index"/>.
		/// </returns>
		/// <param name="index">The index of the object to return.</param><exception cref="T:System.NotImplementedException">Always.</exception>
		public override HttpPostedFileBase Get(int index)
		{
			return (HttpPostedFileBase) collection.Get(index);
		}

		/// <summary>
		/// Returns the posted file object that has the specified name from the collection.
		/// </summary>
		/// <returns>
		/// The posted file object that is specified by <paramref name="name"/>.
		/// </returns>
		/// <param name="name">The name of the object to return.</param><exception cref="T:System.NotImplementedException">Always.</exception>
		public override HttpPostedFileBase Get(string name)
		{
			return (HttpPostedFileBase)collection.Get(name);
		}

		/// <summary>
		/// Returns an enumerator that can be used to iterate through the collection.
		/// </summary>
		/// <returns>
		/// An object that can be used to iterate through the collection.
		/// </returns>
		/// <exception cref="T:System.NotImplementedException">Always.</exception>
		public override IEnumerator GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		/// <summary>
		/// Returns the name of the posted file object at the specified index.
		/// </summary>
		/// <returns>
		/// The name of the posted file object that is specified by <paramref name="index"/>.
		/// </returns>
		/// <param name="index">The index of the object name to return.</param><exception cref="T:System.NotImplementedException">Always.</exception>
		public override string GetKey(int index)
		{
			return collection.GetKey(index);
		}

		/// <summary>
		/// Gets an array that contains the keys (names) of all posted file objects in the collection.
		/// </summary>
		/// <returns>
		/// An array of file names.
		/// </returns>
		/// <exception cref="T:System.NotImplementedException">Always.</exception>
		public override string[] AllKeys
		{
			get { return collection.GetAllKeys(); }
		}

		/// <summary>
		/// Gets the number of posted file objects in the collection.
		/// </summary>
		/// <returns>
		/// The number of objects in the collection.
		/// </returns>
		/// <exception cref="T:System.NotImplementedException">Always.</exception>
		public override int Count
		{
			get { return collection.Count; }
		}

		/// <summary>
		/// Gets a value that indicates whether access to the collection is thread-safe.
		/// </summary>
		/// <returns>
		/// true if access is synchronized (thread-safe); otherwise, false.
		/// </returns>
		/// <exception cref="T:System.NotImplementedException">Always.</exception>
		public override bool IsSynchronized
		{
			get { return ((ICollection)collection).IsSynchronized; }
		}

		/// <summary>
		/// Gets an object that can be used to synchronize access to the collection.
		/// </summary>
		/// <returns>
		/// An object that can be used to synchronize access to the collection.
		/// </returns>
		/// <exception cref="T:System.NotImplementedException">Always.</exception>
		public override object SyncRoot
		{
			get { return ((ICollection) collection).SyncRoot; }
		}

		/// <summary>
		/// Gets the posted file object that has the specified name from the collection.
		/// </summary>
		/// <returns>
		/// The posted file object that is specified by <paramref name="name"/>.
		/// </returns>
		/// <param name="name">The name of the object to return.</param><exception cref="T:System.NotImplementedException">Always.</exception>
		public override HttpPostedFileBase this[string name]
		{
			get
			{
				return (HttpPostedFileBase)collection.Get(name);
			}
		}

		/// <summary>
		/// Gets the posted file object at the specified index.
		/// </summary>
		/// <returns>
		/// The posted file object specified by <paramref name="index"/>.
		/// </returns>
		/// <param name="index">The index of the object to get.</param><exception cref="T:System.NotImplementedException">Always.</exception>
		public override HttpPostedFileBase this[int index]
		{
			get { return (HttpPostedFileBase)collection.Get(index); }
		}

		/// <summary>
		/// Gets a <see cref="T:System.Collections.Specialized.NameObjectCollectionBase.KeysCollection"/> instance that contains all the keys in the <see cref="T:System.Collections.Specialized.NameObjectCollectionBase"/> instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Specialized.NameObjectCollectionBase.KeysCollection"/> instance that contains all the keys in the <see cref="T:System.Collections.Specialized.NameObjectCollectionBase"/> instance.
		/// </returns>
		public override KeysCollection Keys
		{
			get { return collection.Keys; }
		}

		/// <summary>
		/// Implements the <see cref="T:System.Runtime.Serialization.ISerializable"/> interface and returns the data needed to serialize the <see cref="T:System.Collections.Specialized.NameObjectCollectionBase"/> instance.
		/// </summary>
		/// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo"/> object that contains the information required to serialize the <see cref="T:System.Collections.Specialized.NameObjectCollectionBase"/> instance.</param><param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext"/> object that contains the source and destination of the serialized stream associated with the <see cref="T:System.Collections.Specialized.NameObjectCollectionBase"/> instance.</param><exception cref="T:System.ArgumentNullException"><paramref name="info"/> is null.</exception>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			collection.GetObjectData(info, context);
		}

		/// <summary>
		/// Implements the <see cref="T:System.Runtime.Serialization.ISerializable"/> interface and raises the deserialization event when the deserialization is complete.
		/// </summary>
		/// <param name="sender">The source of the deserialization event.</param><exception cref="T:System.Runtime.Serialization.SerializationException">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> object associated with the current <see cref="T:System.Collections.Specialized.NameObjectCollectionBase"/> instance is invalid.</exception>
		public override void OnDeserialization(object sender)
		{
			collection.OnDeserialization(sender);
		}

		private class CaseInsensitiveNameObjectCollection : NameObjectCollectionBase
		{
			public CaseInsensitiveNameObjectCollection()
				: base(StringComparer.InvariantCultureIgnoreCase)
			{

			}

			public void Add(string formFieldValue, FakeHttpPostedFile file)
			{
				BaseAdd(formFieldValue, file);
			}

			public object Get(int index)
			{
				return BaseGet(index);
			}

			public object Get(string name)
			{
				return BaseGet(name);
			}

			public string GetKey(int index)
			{
				return BaseGetKey(index);
			}

			public string[] GetAllKeys()
			{
				return BaseGetAllKeys();
			}

		}
	}

}