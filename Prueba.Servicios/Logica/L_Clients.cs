using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;

namespace Prueba.Servicios.Logica
{
    public class L_Clients
    {
        MongoClient Client = null;
        IMongoDatabase Db = null;
        IMongoCollection<Modelos.M_Clients> Coleccion = null;
        public L_Clients()
        {
            try
            {
                Client = new MongoClient(
                    "mongodb+srv://HBetancourt:r73TaD92CnDGDHkR@cluster0-pclif.mongodb.net/test?retryWrites=true"
                );
                Db = Client.GetDatabase("test");
                Coleccion = Db.GetCollection<Modelos.M_Clients>("Clients");
            }
            catch (Exception ex)
            {
                Registros(ex);
            }
        }

        public List<Modelos.M_Clients> ObtenerTodos()
        {
            try
            {
                return Coleccion.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                Registros(ex);
                return null;
            }
        }

        public Modelos.M_Clients ObtenerUno(string SharedKey)
        {
            try
            {
                return (Modelos.M_Clients)Coleccion.Find(Builders<Modelos.M_Clients>.Filter.Eq("_id", new MongoDB.Bson.ObjectId(SharedKey))).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Registros(ex);
                return null;
            }
        }

        public bool Guardar(Modelos.M_Clients Client)
        {
            try
            {
                Client.SharedKey = null;
                Coleccion.InsertOne(Client);
                return true;
            }
            catch (Exception ex)
            {
                Registros(ex);
                return false;
            }
        }

        public bool Eliminar(string SharedKey)
        {
            try
            {
                return Coleccion.DeleteMany(Builders<Modelos.M_Clients>.Filter.Eq("_id", new MongoDB.Bson.ObjectId(SharedKey))).DeletedCount > 0;
            }
            catch (Exception ex)
            {
                Registros(ex);
                return false;
            }
        }

        public bool Actualizar(Modelos.M_Clients Client)
        {
            try
            {
                if (Eliminar(Client.SharedKey))
                {
                    Client.SharedKey = null;
                    return Guardar(Client);
                }
                return false;
            }
            catch (Exception ex)
            {
                Registros(ex);
                return false;
            }
        }

        void Registros(Exception ex)
        {
            Registros(string.Format("[Message:{0} --- StackTrace:{1} --- Source:{2}]", ex.Message, ex.StackTrace, ex.Source));
            if (ex.InnerException != null)
            {
                Registros(ex.InnerException);
            }
        }
        void Registros(string text)
        {
            try
            {
                string Ruta = System.Reflection.Assembly.GetEntryAssembly().Location;

                System.IO.File.WriteAllText(Ruta + "\\Log.txt", text);
            }
            catch (Exception)
            {
            }
        }
    }
}