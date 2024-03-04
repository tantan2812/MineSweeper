using Android.App;
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
    /// <summary>
    /// Provides a centralized interface for interacting with Firebase services such as Firebase Authentication and Firestore.
    /// </summary>
    internal class FbData
    {
        private readonly FirebaseAuth auth;
        private readonly FirebaseFirestore firestore;

        /// <summary>
        /// Provides functionality for interacting with Firebase services such as authentication and Firestore database.
        /// </summary>
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

        /// <summary>
        /// Retrieves the Firebase project options for initialization.
        /// </summary>
        /// <returns>FirebaseOptions object with project-specific settings.</returns>
        private FirebaseOptions GetMyOptions()
        {
            return new FirebaseOptions.Builder()
                    .SetProjectId("minesweeper-f2fb0")
                    .SetApplicationId("1:391762564662:android:4a9e0e8f43a4c0c83baa97")
                    .SetApiKey("AIzaSyBsyMPZv344ro5dE5XDynT__-suV5BFO74")
                    .SetStorageBucket("minesweeper-f2fb0.appspot.com")
                    .Build();
        }

        /// <summary>
        /// Registers a new user with the specified email and password.
        /// </summary>
        /// <param name="email">The email address of the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>A Task representing the registration operation.</returns>
        public Task Register(string email, string password)
        {
            return auth.CreateUserWithEmailAndPassword(email, password);
        }

        /// <summary>
        /// Logs in an existing user with the specified email and password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A Task representing the login operation.</returns>
        public Task Login(string email, string password)
        {
            return auth.SignInWithEmailAndPassword(email, password);
        }

        /// <summary>
        /// Retrieves the unique identifier (UID) of the currently logged-in user.
        /// </summary>
        /// <returns>The UID of the current user, or an empty string if no user is logged in.</returns>
        public string GetUserId()
        {
            return auth.CurrentUser is null ? string.Empty : auth.CurrentUser.Uid;
        }

        /// <summary>
        /// Sends a password reset email to the specified email address.
        /// </summary>
        /// <param name="email">The email address to send the reset email to.</param>
        /// <returns>A Task representing the password reset operation.</returns>
        public Task ResetPassword(string email)
        {
            return auth.SendPasswordResetEmail(email);
        }

        /// <summary>
        /// Sets or updates a document in the specified Firestore collection.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to set or update. If empty, a new document ID will be generated.</param>
        /// <param name="newId">The generated document ID, if a new document is created.</param>
        /// <param name="hm">A HashMap containing the fields and values to set or update in the document.</param>
        /// <returns>A Task representing the set or update operation.</returns>
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

        /// <summary>
        /// Deletes a document from the specified Firestore collection.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to delete.</param>
        /// <returns>A Task representing the delete operation.</returns>
        public Task DeleteDocument(string cName, string docId)
        {
            return firestore.Collection(cName).Document(docId).Delete();
        }

        /// <summary>
        /// Retrieves a document from the specified Firestore collection.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to retrieve.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetDocument(string cName, string docId)
        {
            //DocumentSnapshot(task.Result)
            return firestore.Collection(cName).Document(docId).Get();
        }

        /// <summary>
        /// Retrieves all documents from the specified Firestore collection.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetCollection(string cName)
        {
            //(QuerySnapshot)task.Result
            return firestore.Collection(cName).Get();
        }

        /// <summary>
        /// Updates a specific field in a Firestore document.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to update.</param>
        /// <param name="fName">The name of the field to update.</param>
        /// <param name="num">The new numeric value for the field.</param>
        /// <returns>A Task representing the update operation.</returns>
        public Task UpdateField(string cName, string docId, string fName, int num)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, num);
        }

        /// <summary>
        /// Updates a specific field in a Firestore document.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to update.</param>
        /// <param name="fName">The name of the field to update.</param>
        /// <param name="str">The new string value for the field.</param>
        /// <returns>A Task representing the update operation.</returns>
        public Task UpdateField(string cName, string docId, string fName, string str)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, str);
        }

        /// <summary>
        /// Updates a specific field in a Firestore document.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to update.</param>
        /// <param name="fName">The name of the field to update.</param>
        /// <param name="jl">The new JavaList value for the field.</param>
        /// <returns>A Task representing the update operation.</returns>
        public Task UpdateField(string cName, string docId, string fName, JavaList jl)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, jl);
        }

        /// <summary>
        /// Retrieves documents from a Firestore collection where a specific field matches a given value.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="fName">The name of the field to match.</param>
        /// <param name="fValue">The value to match against the field.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetEqualToDocs(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereEqualTo(fName, fValue).Get();
        }

        /// <summary>
        /// Retrieves documents from a Firestore collection where a specific field is greater than a given value.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="fName">The name of the field to compare.</param>
        /// <param name="fValue">The value to compare against the field.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetGreaterThan(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereGreaterThan(fName, fValue).Get();
        }

        /// <summary>
        /// Retrieves documents from a Firestore collection where a specific field is greater than or equal to a given value.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="fName">The name of the field to compare.</param>
        /// <param name="fValue">The value to compare against the field.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetGreaterThanOrEqual(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereGreaterThanOrEqualTo(fName, fValue).Get();
        }

        /// <summary>
        /// Retrieves documents from a Firestore collection where a specific field is less than a given value.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="fName">The name of the field to compare.</param>
        /// <param name="fValue">The value to compare against the field.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetLessThan(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereLessThan(fName, fValue).Get();
        }

        /// <summary>
        /// Retrieves documents from a Firestore collection where a specific field is less than or equal to a given value.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="fName">The name of the field to compare.</param>
        /// <param name="fValue">The value to compare against the field.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetLessThanOrEqual(string cName, string fName, Java.Lang.Object fValue)
        {
            return firestore.Collection(cName).WhereLessThanOrEqualTo(fName, fValue).Get();
        }

        /// <summary>
        /// Increments a numeric field in a Firestore document by a specified amount.
        /// </summary>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to update.</param>
        /// <param name="fName">The name of the field to increment.</param>
        /// <param name="incrementBy">The amount by which to increment the field.</param>
        /// <returns>A Task representing the update operation.</returns>
        public Task IncrementField(string cName, string docId, string fName, double incrementBy)
        {
            return firestore.Collection(cName).Document(docId).Update(fName, FieldValue.Increment(incrementBy));
        }

        /// <summary>
        /// Adds a snapshot listener to a Firestore collection.
        /// </summary>
        /// <param name="activity">The Activity that will handle the listener events.</param>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <returns>An IListenerRegistration that can be used to remove the listener.</returns>
        public IListenerRegistration AddSnapshotListener(Activity activity, string cName)
        {
            return firestore.Collection(cName).AddSnapshotListener((Firebase.Firestore.IEventListener)activity);
        }

        /// <summary>
        /// Adds a snapshot listener to a specific document in a Firestore collection.
        /// </summary>
        /// <param name="activity">The Activity that will handle the listener events.</param>
        /// <param name="cName">The name of the Firestore collection.</param>
        /// <param name="docId">The ID of the document to listen to.</param>
        /// <returns>An IListenerRegistration that can be used to remove the listener.</returns>
        public IListenerRegistration AddSnapshotListener(Activity activity, string cName, string docId)
        {
            return firestore.Collection(cName).Document(docId).AddSnapshotListener((Firebase.Firestore.IEventListener)activity);
        }

        /// <summary>
        /// Saves an image to Firebase Storage.
        /// </summary>
        /// <param name="fbImagePath">The path in Firebase Storage where the image will be saved.</param>
        /// <param name="bitmap">The Bitmap image to save.</param>
        /// <returns>An UploadTask representing the upload operation.</returns>
        public UploadTask SaveImage(string fbImagePath, Bitmap bitmap)
        {
            StorageReference storageReference = FirebaseStorage.Instance.GetReference(fbImagePath);
            Byte[] imgBytes = General.BitmapToByteArray(bitmap);
            return storageReference.PutBytes(imgBytes);
        }

        /// <summary>
        /// Retrieves the download URL of an image from Firebase Storage.
        /// </summary>
        /// <param name="fbImagePath">The path of the image in Firebase Storage.</param>
        /// <returns>A Task representing the retrieval operation.</returns>
        public Task GetDownloadUrl(string fbImagePath)
        {
            //(Android.Net.Uri)task.Result
            StorageReference storageReference = FirebaseStorage.Instance.GetReference(fbImagePath);
            return storageReference.GetDownloadUrl();
        }

        /// <summary>
        /// Generates a new, unique collection ID.
        /// </summary>
        /// <returns>A new, unique collection ID as a string.</returns>
        public string GetNewCollectionId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        /// <summary>
        /// Converts a .NET DateTime to a Firestore Timestamp.
        /// </summary>
        /// <param name="dt">The .NET DateTime to convert.</param>
        /// <returns>A Firestore Timestamp equivalent to the .NET DateTime.</returns>
        public Java.Sql.Timestamp DateTimeToFirestoreTimestamp(DateTime dt)
        {
            dt = TimeZoneInfo.ConvertTimeToUtc(dt);
            DateTime ofset = new DateTime(1970, 1, 1);
            TimeSpan ts = dt - new DateTime(ofset.Ticks);
            return new Java.Sql.Timestamp((long)ts.TotalMilliseconds);
        }

        /// <summary>
        /// Converts a Firestore Timestamp to a .NET DateTime.
        /// </summary>
        /// <param name="ts">The Firestore Timestamp to convert.</param>
        /// <returns>A .NET DateTime equivalent to the Firestore Timestamp.</returns>
        public DateTime FirestoreTimestampToDateTime(Firebase.Timestamp ts)
        {
            Java.Util.Date d = ts.ToDate();
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(d.Time);
            return TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Creates a new user account with the specified email and password.
        /// </summary>
        /// <param name="email">The email address for the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <returns>A Task representing the user creation operation.</returns>
        public Task CreateUser(string email, string password)
        {
            return auth.CreateUserWithEmailAndPassword(email, password);
        }

        /// <summary>
        /// Updates the display name of the currently logged-in user.
        /// </summary>
        /// <param name="name">The new display name for the user.</param>
        /// <returns>A Task representing the user profile update operation.</returns>
        public Task UpdateUserName(string name)
        {
            UserProfileChangeRequest upcr = new UserProfileChangeRequest.Builder()
                   .SetDisplayName(name)
                   .Build();
            return auth.CurrentUser.UpdateProfile(upcr);
        }

        /// <summary>
        /// Signs in an existing user with the specified email and password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A Task representing the sign-in operation.</returns>
        public Task SignIn(string email, string password)
        {
            return auth.SignInWithEmailAndPassword(email, password);
        }

        /// <summary>
        /// Sends a verification email to the currently logged-in user.
        /// </summary>
        /// <returns>A Task representing the email verification operation.</returns>
        internal Task SendVerifyEmail()
        {
            return auth.CurrentUser.SendEmailVerification();
        }

        /// <summary>
        /// Deletes the currently logged-in user account.
        /// </summary>
        /// <returns>A Task representing the user deletion operation.</returns>
        internal Task DeleteUser()
        {
            return auth.CurrentUser.Delete();
        }

        /// <summary>
        /// Indicates whether a user is currently signed in.
        /// </summary>
        /// <value>True if a user is signed in, false otherwise.</value>
        internal bool UserConnected => !(auth.CurrentUser is null);

        /// <summary>
        /// Indicates whether the currently logged-in user's email is verified.
        /// </summary>
        /// <value>True if the user's email is verified, false otherwise.</value>
        internal bool IsEmailVerifid => auth.CurrentUser.IsEmailVerified;

    }
}