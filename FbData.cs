﻿using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase.Storage;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace MineSweeper
{
    internal class FbData
    {
        private readonly FirebaseAuth auth;
        private readonly FirebaseFirestore firestore;

        public FbData()
        {
            Firebase.FirebaseApp app = Firebase.FirebaseApp.InitializeApp(Application.Context);
            if (app is null)
            {
                FirebaseOptions options = GetMyOptions();
                app = Firebase.FirebaseApp.InitializeApp(Application.Context, options);
            }
            auth = FirebaseAuth.Instance;
            firestore = FirebaseFirestore.GetInstance(app);
        }

        private FirebaseOptions GetMyOptions()
        {
            return new FirebaseOptions.Builder()
                    .SetProjectId("minesweeper-f2fb0")
                    .SetApplicationId("1:391762564662:android:4a9e0e8f43a4c0c83baa97")
                    .SetApiKey("AIzaSyBsyMPZv344ro5dE5XDynT__-suV5BFO74")
                    .SetStorageBucket("minesweeper-f2fb0.appspot.com")
                    .Build();
        }

        public Task Register(string email, string password)
        {
            return auth.CreateUserWithEmailAndPassword(email, password);
        }

        public Task Login(string email, string password)
        {
            return auth.SignInWithEmailAndPassword(email, password);
        }

        public string GetUserId()
        {
            return auth.CurrentUser is null ? string.Empty : auth.CurrentUser.Uid;
        }

        public Task ResetPassword(string email)
        {
            return auth.SendPasswordResetEmail(email);
        }

        public Task SetDocument(string cName, string docId, out string newId, HashMap hm)
        {
            Task t;
            if (docId != string.Empty)
            {
                t = firestore.Collection(cName).Document(docId).Set(hm);
                newId = docId;
            }
            else
            {
                DocumentReference dr = firestore.Collection(cName).Document();
                newId = dr.Id;
                t = dr.Set(hm);
            }
            return t;
        }

        public Task DeleteDocument(string cName, string docId)
        {
            return firestore.Collection(cName).Document(docId).Delete();
        }
        public Task GetDocument(string cName, string docId)
        {
            //DocumentSnapshot(task.Result)
            return firestore.Collection(cName).Document(docId).Get();
        }

        public Task GetCollection(string cName)
        {
            //(QuerySnapshot)task.Result
            return firestore.Collection(cName).Get();
        }

        public Task UpdateField(string cName, string docId, string fName, int num)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, num);
        }
        public Task UpdateField(string cName, string docId, string fName, string str)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, str);
        }
        public Task UpdateField(string cName, string docId, string fName, JavaList jl)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, jl);
        }

        public Task GetEqualToDocs(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereEqualTo(fName, fValue).Get();
        }

        public Task GetGreaterThan(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereGreaterThan(fName, fValue).Get();
        }
        public Task GetGreaterThanOrEqual(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereGreaterThanOrEqualTo(fName, fValue).Get();
        }

        public Task GetLessThan(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereLessThan(fName, fValue).Get();
        }
        public Task GetLessThanOrEqual(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereLessThanOrEqualTo(fName, fValue).Get();
        }
        public Task IncrementField(string cName, string docId, string fName, double incrementBy)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, FieldValue.Increment(incrementBy));
        }

        public IListenerRegistration AddSnapshotListener(Activity activity, string cName)
        {
            return firestore.Collection(cName).AddSnapshotListener((Firebase.Firestore.IEventListener)activity);
        }

        public IListenerRegistration AddSnapshotListener(Activity activity, string cName, string docId)
        {
            return firestore.Collection(cName).Document(docId).AddSnapshotListener((Firebase.Firestore.IEventListener)activity);
        }


        public UploadTask SaveImage(string fbImagePath, Bitmap bitmap)
        {
            StorageReference storageReference = FirebaseStorage.Instance.GetReference(fbImagePath);
            Byte[] imgBytes = General.BitmapToByteArray(bitmap);
            return storageReference.PutBytes(imgBytes);
        }

        public Task GetDownloadUrl(string fbImagePath)
        {
            //(Android.Net.Uri)task.Result
            StorageReference storageReference = FirebaseStorage.Instance.GetReference(fbImagePath);
            return storageReference.GetDownloadUrl();
        }
        public string GetNewCollectionId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        public Java.Sql.Timestamp DateTimeToFirestoreTimestamp(DateTime dt)
        {
            dt = TimeZoneInfo.ConvertTimeToUtc(dt);
            DateTime ofset = new DateTime(1970, 1, 1);
            TimeSpan ts = dt - new DateTime(ofset.Ticks);
            return new Java.Sql.Timestamp((long)ts.TotalMilliseconds);
        }

        public DateTime FirestoreTimestampToDateTime(Firebase.Timestamp ts)
        {
            Java.Util.Date d = ts.ToDate();
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(d.Time);
            return TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.Local);
        }
        public Task CreateUser(string email, string password)
        {
            return auth.CreateUserWithEmailAndPassword(email, password);
        }
        public Task UpdateUserName(string name)
        {
            UserProfileChangeRequest upcr = new UserProfileChangeRequest.Builder()
                   .SetDisplayName(name)
                   .Build();
            return auth.CurrentUser.UpdateProfile(upcr);
        }

        public Task SignIn(string email, string password)
        {
            return auth.SignInWithEmailAndPassword(email, password);
        }

        internal Task SendVerifyEmail()
        {
            return auth.CurrentUser.SendEmailVerification();
        }

        internal Task DeleteUser()
        {
            return auth.CurrentUser.Delete();
        }

        internal bool UserConnected => !(auth.CurrentUser is null);
        internal bool IsEmailVerifid => auth.CurrentUser.IsEmailVerified;

    }
}