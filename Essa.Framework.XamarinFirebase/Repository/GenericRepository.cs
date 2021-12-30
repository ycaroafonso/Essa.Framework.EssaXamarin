using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace Essa.Framework.XamarinFirebase.Repository
{

    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        FirebaseClient firebase;

        protected readonly object locker;
        private readonly string _nometabela;



        private ChildQuery _tabela { get; set; }

        public GenericRepository(string url, string nometabela)
        {
            firebase = new FirebaseClient(url);
            this._nometabela = nometabela;

            _tabela = firebase.Child(_nometabela);
        }

        public void Initialize()
        {
            //FirebaseApp firebaseApp = FirebaseApp.InitializeApp(Application.Context);
            //FirebaseDatabase.GetInstance(firebaseApp).SetPersistenceEnabled(true);
            //firebaseDatabase = FirebaseDatabase.GetInstance(firebaseApp);
            //firebaseAuth = FirebaseAuth.GetInstance(firebaseApp);
            //firebaseStorage = FirebaseStorage.Instance;

            //GetUser();
        }
















        public async Task<List<T>> ObterTodos()
        {
            return (await _tabela.OnceAsync<T>()).Select(c => c.Object).ToList();
        }
        public async Task<List<T>> ObterTodos(Func<FirebaseObject<T>, bool> predicate)
        {
            return (await _tabela.OnceAsync<T>()).Where(predicate).Select(c => c.Object).ToList();
        }



        public Task<IReadOnlyCollection<FirebaseObject<T>>> ObterTodosBruto()
        {
            return _tabela.OnceAsync<T>();
        }


        public async Task<FirebaseObject<T>> IncluirAsync(T item)
        {
            FirebaseObject<T> x = await _tabela.PostAsync(item);
            return x;
        }





        public async Task AtualizarAsync(Func<FirebaseObject<T>, bool> predicate, T item)
        {
            FirebaseObject<T> toUpdatePerson = (await _tabela
              .OnceAsync<T>()).Where(predicate).FirstOrDefault();

            await _tabela
              .Child(toUpdatePerson.Key)
              .PutAsync(item);
        }
        public async Task Atualizar(FirebaseObject<T> item)
        {
            await _tabela.Child(item.Key).PutAsync(item);
        }




        public async Task ExcluirAsync(Func<T, bool> predicate)
        {
            await ExcluirAsync(predicate);
        }
        public async Task ExcluirAsync(FirebaseObject<T> item)
        {
            await _tabela.Child(item.Key).DeleteAsync();
        }


    }
}
