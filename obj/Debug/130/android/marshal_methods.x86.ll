; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [256 x i32] [
	i32 6657927, ; 0: Xamarin.Grpc.Protobuf.Lite.dll => 0x659787 => 101
	i32 9279650, ; 1: Xamarin.Firebase.AppCheck => 0x8d98a2 => 73
	i32 9414545, ; 2: Xamarin.Grpc.Android => 0x8fa791 => 96
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 51
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 90
	i32 39109920, ; 5: Newtonsoft.Json.dll => 0x254c520 => 6
	i32 57305218, ; 6: Xamarin.KotlinX.Coroutines.Play.Services => 0x36a6882 => 113
	i32 101534019, ; 7: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 61
	i32 103834273, ; 8: Xamarin.Firebase.Annotations.dll => 0x63062a1 => 72
	i32 120558881, ; 9: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 61
	i32 134690465, ; 10: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 108
	i32 165246403, ; 11: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 35
	i32 182336117, ; 12: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 63
	i32 209399409, ; 13: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 33
	i32 227054016, ; 14: Xamarin.GoogleAndroid.Annotations.dll => 0xd8891c0 => 91
	i32 230216969, ; 15: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 48
	i32 232815796, ; 16: System.Web.Services => 0xde07cb4 => 125
	i32 266337479, ; 17: Xamarin.Google.Guava.FailureAccess.dll => 0xfdffcc7 => 89
	i32 271099684, ; 18: Xamarin.Grpc.OkHttp => 0x1028a724 => 100
	i32 280482487, ; 19: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 46
	i32 288057472, ; 20: MineSweeper.dll => 0x112b6880 => 0
	i32 293936332, ; 21: Xamarin.GooglePlayServices.Auth.Api.Phone.dll => 0x11851ccc => 92
	i32 318968648, ; 22: Xamarin.AndroidX.Activity.dll => 0x13031348 => 24
	i32 321597661, ; 23: System.Numerics => 0x132b30dd => 19
	i32 342366114, ; 24: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 49
	i32 347068432, ; 25: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 10
	i32 385762202, ; 26: System.Memory.dll => 0x16fe439a => 17
	i32 442521989, ; 27: Xamarin.Essentials => 0x1a605985 => 71
	i32 443493152, ; 28: Xamarin.Google.Android.Recaptcha => 0x1a6f2b20 => 86
	i32 450948140, ; 29: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 45
	i32 453011810, ; 30: Xamarin.Firebase.Database.Collection.dll => 0x1b006962 => 80
	i32 465846621, ; 31: mscorlib => 0x1bc4415d => 5
	i32 469710990, ; 32: System.dll => 0x1bff388e => 16
	i32 476646585, ; 33: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 46
	i32 486930444, ; 34: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 55
	i32 493301629, ; 35: Xamarin.Firebase.AppCheck.Interop.dll => 0x1d672f7d => 74
	i32 526420162, ; 36: System.Transactions.dll => 0x1f6088c2 => 118
	i32 527452488, ; 37: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 108
	i32 557405415, ; 38: Jsr305Binding => 0x213954e7 => 3
	i32 589597883, ; 39: Xamarin.GooglePlayServices.Auth.Api.Phone => 0x23248cbb => 92
	i32 605376203, ; 40: System.IO.Compression.FileSystem => 0x24154ecb => 121
	i32 627609679, ; 41: Xamarin.AndroidX.CustomView => 0x2568904f => 42
	i32 663517072, ; 42: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 68
	i32 666292255, ; 43: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 30
	i32 690569205, ; 44: System.Xml.Linq.dll => 0x29293ff5 => 126
	i32 691348768, ; 45: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 110
	i32 700284507, ; 46: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 105
	i32 712915335, ; 47: Xamarin.Grpc.Api => 0x2a7e3987 => 97
	i32 714456728, ; 48: Square.OkIO.JVM.dll => 0x2a95be98 => 13
	i32 720511267, ; 49: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 109
	i32 748832960, ; 50: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 8
	i32 763781610, ; 51: Xamarin.Google.Android.Play.Integrity => 0x2d8661ea => 85
	i32 775507847, ; 52: System.IO.Compression => 0x2e394f87 => 120
	i32 809851609, ; 53: System.Drawing.Common.dll => 0x30455ad9 => 115
	i32 843511501, ; 54: Xamarin.AndroidX.Print => 0x3246f6cd => 57
	i32 928116545, ; 55: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 90
	i32 955402788, ; 56: Newtonsoft.Json => 0x38f24a24 => 6
	i32 956575887, ; 57: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 109
	i32 961995525, ; 58: Square.OkIO.dll => 0x3956e305 => 12
	i32 967690846, ; 59: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 49
	i32 1012816738, ; 60: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 60
	i32 1031528504, ; 61: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 87
	i32 1035644815, ; 62: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 29
	i32 1052210849, ; 63: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 52
	i32 1067306892, ; 64: GoogleGson => 0x3f9dcf8c => 1
	i32 1084122840, ; 65: Xamarin.Kotlin.StdLib => 0x409e66d8 => 107
	i32 1098259244, ; 66: System => 0x41761b2c => 16
	i32 1110581358, ; 67: Xamarin.Firebase.Auth => 0x4232206e => 75
	i32 1111591002, ; 68: Xamarin.CodeHaus.Mojo.AnimalSnifferAnnotations => 0x4241885a => 70
	i32 1159499262, ; 69: Xamarin.Grpc.Stub.dll => 0x451c8dfe => 102
	i32 1175144683, ; 70: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 66
	i32 1204270330, ; 71: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 30
	i32 1230765884, ; 72: Xamarin.Grpc.Stub => 0x495bff3c => 102
	i32 1246548578, ; 73: Xamarin.AndroidX.Collection.Jvm.dll => 0x4a4cd262 => 36
	i32 1263886435, ; 74: Xamarin.Google.Guava.dll => 0x4b556063 => 88
	i32 1264511973, ; 75: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 62
	i32 1264890200, ; 76: Xamarin.KotlinX.Coroutines.Core.dll => 0x4b64b158 => 111
	i32 1267360935, ; 77: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 67
	i32 1275534314, ; 78: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 110
	i32 1278448581, ; 79: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 27
	i32 1292207520, ; 80: SQLitePCLRaw.core.dll => 0x4d0585a0 => 9
	i32 1293217323, ; 81: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 44
	i32 1316849161, ; 82: Xamarin.Io.PerfMark.PerfMarkApi => 0x4e7d8609 => 103
	i32 1333047053, ; 83: Xamarin.Firebase.Common => 0x4f74af0d => 77
	i32 1365406463, ; 84: System.ServiceModel.Internals.dll => 0x516272ff => 124
	i32 1376866003, ; 85: Xamarin.AndroidX.SavedState => 0x52114ed3 => 60
	i32 1379897097, ; 86: Xamarin.JavaX.Inject => 0x523f8f09 => 104
	i32 1406073936, ; 87: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 38
	i32 1406299041, ; 88: Xamarin.Google.Guava.FailureAccess => 0x53d26ba1 => 89
	i32 1411638395, ; 89: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 21
	i32 1411702249, ; 90: Xamarin.Firebase.Auth.Interop.dll => 0x5424dde9 => 76
	i32 1462112819, ; 91: System.IO.Compression.dll => 0x57261233 => 120
	i32 1469204771, ; 92: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 28
	i32 1544135863, ; 93: Xamarin.Grpc.Api.dll => 0x5c09a4b7 => 97
	i32 1582372066, ; 94: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 43
	i32 1592978981, ; 95: System.Runtime.Serialization.dll => 0x5ef2ee25 => 123
	i32 1597949149, ; 96: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 87
	i32 1622152042, ; 97: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 54
	i32 1636350590, ; 98: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 41
	i32 1639515021, ; 99: System.Net.Http.dll => 0x61b9038d => 18
	i32 1657153582, ; 100: System.Runtime => 0x62c6282e => 22
	i32 1658241508, ; 101: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 64
	i32 1658251792, ; 102: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 84
	i32 1664238415, ; 103: Xamarin.Firebase.Database.Collection => 0x6332434f => 80
	i32 1698840827, ; 104: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 106
	i32 1711441057, ; 105: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 10
	i32 1729485958, ; 106: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 34
	i32 1748729059, ; 107: Xamarin.GoogleAndroid.Annotations => 0x683b7ce3 => 91
	i32 1766324549, ; 108: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 63
	i32 1776026572, ; 109: System.Core.dll => 0x69dc03cc => 15
	i32 1788241197, ; 110: Xamarin.AndroidX.Fragment => 0x6a96652d => 45
	i32 1808609942, ; 111: Xamarin.AndroidX.Loader => 0x6bcd3296 => 54
	i32 1813058853, ; 112: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 107
	i32 1813201214, ; 113: Xamarin.Google.Android.Material => 0x6c13413e => 84
	i32 1867746548, ; 114: Xamarin.Essentials.dll => 0x6f538cf4 => 71
	i32 1875053220, ; 115: Xamarin.Firebase.Auth.Interop => 0x6fc30aa4 => 76
	i32 1885316902, ; 116: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 31
	i32 1908813208, ; 117: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 94
	i32 1919157823, ; 118: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 56
	i32 1983156543, ; 119: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 106
	i32 2011961780, ; 120: System.Buffers.dll => 0x77ec19b4 => 14
	i32 2019465201, ; 121: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 52
	i32 2055257422, ; 122: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 50
	i32 2079903147, ; 123: System.Runtime.dll => 0x7bf8cdab => 22
	i32 2083657273, ; 124: Xamarin.Firebase.ProtoliteWellKnownTypes => 0x7c321639 => 82
	i32 2086218969, ; 125: Xamarin.Google.Android.Play.Integrity.dll => 0x7c592cd9 => 85
	i32 2090596640, ; 126: System.Numerics.Vectors => 0x7c9bf920 => 20
	i32 2097448633, ; 127: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 47
	i32 2103459038, ; 128: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 11
	i32 2129483829, ; 129: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 93
	i32 2174878672, ; 130: Xamarin.Firebase.Annotations => 0x81a203d0 => 72
	i32 2195564014, ; 131: Xamarin.Grpc.Context => 0x82dda5ee => 98
	i32 2201107256, ; 132: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 112
	i32 2201231467, ; 133: System.Net.Http => 0x8334206b => 18
	i32 2217644978, ; 134: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 66
	i32 2225853105, ; 135: Xamarin.Firebase.Common.Ktx => 0x84abd2b1 => 78
	i32 2244775296, ; 136: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 55
	i32 2256548716, ; 137: Xamarin.AndroidX.MultiDex => 0x8680336c => 56
	i32 2279755925, ; 138: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 59
	i32 2305348475, ; 139: Xamarin.Firebase.Storage.dll => 0x8968d37b => 83
	i32 2315684594, ; 140: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 25
	i32 2382033717, ; 141: Xamarin.Firebase.Auth.dll => 0x8dfaf335 => 75
	i32 2465273461, ; 142: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 8
	i32 2471841756, ; 143: netstandard.dll => 0x93554fdc => 116
	i32 2475788418, ; 144: Java.Interop.dll => 0x93918882 => 2
	i32 2501346920, ; 145: System.Data.DataSetExtensions => 0x95178668 => 119
	i32 2505896520, ; 146: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 51
	i32 2561374756, ; 147: Xamarin.Google.Android.Recaptcha.dll => 0x98ab7a24 => 86
	i32 2581819634, ; 148: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 67
	i32 2591433303, ; 149: Xamarin.Grpc.Core.dll => 0x9a762257 => 99
	i32 2605712449, ; 150: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 112
	i32 2620871830, ; 151: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 41
	i32 2640452924, ; 152: Xamarin.Grpc.Protobuf.Lite => 0x9d621d3c => 101
	i32 2652665316, ; 153: Xamarin.CodeHaus.Mojo.AnimalSnifferAnnotations.dll => 0x9e1c75e4 => 70
	i32 2671474046, ; 154: Xamarin.KotlinX.Coroutines.Core => 0x9f3b757e => 111
	i32 2701096212, ; 155: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 64
	i32 2715831284, ; 156: Xamarin.Firebase.ProtoliteWellKnownTypes.dll => 0xa1e04bf4 => 82
	i32 2732626843, ; 157: Xamarin.AndroidX.Activity => 0xa2e0939b => 24
	i32 2737747696, ; 158: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 28
	i32 2752363754, ; 159: Xamarin.Firebase.Firestore.dll => 0xa40dbcea => 81
	i32 2765528135, ; 160: Xamarin.Io.PerfMark.PerfMarkApi.dll => 0xa4d69c47 => 103
	i32 2770495804, ; 161: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 105
	i32 2778768386, ; 162: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 69
	i32 2799649579, ; 163: Xamarin.Protobuf.JavaLite.dll => 0xa6df432b => 114
	i32 2804607052, ; 164: Xamarin.Firebase.Components.dll => 0xa72ae84c => 79
	i32 2807391857, ; 165: Xamarin.Firebase.AppCheck.dll => 0xa7556671 => 73
	i32 2810250172, ; 166: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 38
	i32 2819470561, ; 167: System.Xml.dll => 0xa80db4e1 => 23
	i32 2847418871, ; 168: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 93
	i32 2853208004, ; 169: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 69
	i32 2855708567, ; 170: Xamarin.AndroidX.Transition => 0xaa36a797 => 65
	i32 2856624150, ; 171: Xamarin.Grpc.Core => 0xaa44a016 => 99
	i32 2870458124, ; 172: Xamarin.Firebase.AppCheck.Interop => 0xab17b70c => 74
	i32 2875164099, ; 173: Jsr305Binding.dll => 0xab5f85c3 => 3
	i32 2903344695, ; 174: System.ComponentModel.Composition => 0xad0d8637 => 122
	i32 2905242038, ; 175: mscorlib.dll => 0xad2a79b6 => 5
	i32 2919462931, ; 176: System.Numerics.Vectors.dll => 0xae037813 => 20
	i32 2921128767, ; 177: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 26
	i32 2943219317, ; 178: Square.OkIO => 0xaf6df675 => 12
	i32 2960379616, ; 179: Xamarin.Google.Guava => 0xb073cee0 => 88
	i32 2978675010, ; 180: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 44
	i32 2997162759, ; 181: MineSweeper => 0xb2a51307 => 0
	i32 3016983068, ; 182: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 62
	i32 3024354802, ; 183: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 48
	i32 3058099980, ; 184: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 95
	i32 3071899978, ; 185: Xamarin.Firebase.Common.dll => 0xb719794a => 77
	i32 3111772706, ; 186: System.Runtime.Serialization => 0xb979e222 => 123
	i32 3148237826, ; 187: GoogleGson.dll => 0xbba64c02 => 1
	i32 3150271759, ; 188: Xamarin.KotlinX.Coroutines.Play.Services.dll => 0xbbc5550f => 113
	i32 3204380047, ; 189: System.Data.dll => 0xbefef58f => 117
	i32 3211777861, ; 190: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 43
	i32 3222740722, ; 191: Xamarin.Protobuf.JavaLite => 0xc0171ef2 => 114
	i32 3230271625, ; 192: Square.OkIO.JVM => 0xc08a0889 => 13
	i32 3230466174, ; 193: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 94
	i32 3247949154, ; 194: Mono.Security => 0xc197c562 => 127
	i32 3258312781, ; 195: Xamarin.AndroidX.CardView => 0xc235e84d => 34
	i32 3267021929, ; 196: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 32
	i32 3286872994, ; 197: SQLite-net.dll => 0xc3e9b3a2 => 7
	i32 3317135071, ; 198: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 42
	i32 3317144872, ; 199: System.Data => 0xc5b79d28 => 117
	i32 3340431453, ; 200: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 31
	i32 3345895724, ; 201: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 58
	i32 3353484488, ; 202: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 47
	i32 3360279109, ; 203: SQLitePCLRaw.core => 0xc849ca45 => 9
	i32 3362522851, ; 204: Xamarin.AndroidX.Core => 0xc86c06e3 => 40
	i32 3366347497, ; 205: Java.Interop => 0xc8a662e9 => 2
	i32 3374999561, ; 206: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 59
	i32 3395150330, ; 207: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 21
	i32 3404865022, ; 208: System.ServiceModel.Internals => 0xcaf21dfe => 124
	i32 3429136800, ; 209: System.Xml => 0xcc6479a0 => 23
	i32 3430777524, ; 210: netstandard => 0xcc7d82b4 => 116
	i32 3437748879, ; 211: Xamarin.Firebase.Storage => 0xcce7e28f => 83
	i32 3473879593, ; 212: Xamarin.Grpc.OkHttp.dll => 0xcf0f3229 => 100
	i32 3476120550, ; 213: Mono.Android => 0xcf3163e6 => 4
	i32 3486566296, ; 214: System.Transactions => 0xcfd0c798 => 118
	i32 3493954962, ; 215: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 37
	i32 3501239056, ; 216: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 32
	i32 3509114376, ; 217: System.Xml.Linq => 0xd128d608 => 126
	i32 3567349600, ; 218: System.ComponentModel.Composition.dll => 0xd4a16f60 => 122
	i32 3597794883, ; 219: Xamarin.Firebase.Firestore => 0xd671fe43 => 81
	i32 3627220390, ; 220: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 57
	i32 3633644679, ; 221: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 26
	i32 3641597786, ; 222: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 50
	i32 3672681054, ; 223: Mono.Android.dll => 0xdae8aa5e => 4
	i32 3676310014, ; 224: System.Web.Services.dll => 0xdb2009fe => 125
	i32 3682565725, ; 225: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 33
	i32 3684561358, ; 226: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 37
	i32 3689375977, ; 227: System.Drawing.Common => 0xdbe768e9 => 115
	i32 3706696989, ; 228: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 39
	i32 3718780102, ; 229: Xamarin.AndroidX.Annotation => 0xdda814c6 => 25
	i32 3754567612, ; 230: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 11
	i32 3786282454, ; 231: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 35
	i32 3829621856, ; 232: System.Numerics.dll => 0xe4436460 => 19
	i32 3876362041, ; 233: SQLite-net => 0xe70c9739 => 7
	i32 3885922214, ; 234: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 65
	i32 3888767677, ; 235: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 58
	i32 3896760992, ; 236: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 40
	i32 3910130544, ; 237: Xamarin.AndroidX.Collection.Jvm => 0xe90fdb70 => 36
	i32 3920810846, ; 238: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 121
	i32 3921031405, ; 239: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 68
	i32 3934056515, ; 240: Xamarin.JavaX.Inject.dll => 0xea7cf043 => 104
	i32 3943739589, ; 241: Xamarin.Grpc.Context.dll => 0xeb10b0c5 => 98
	i32 3945713374, ; 242: System.Data.DataSetExtensions.dll => 0xeb2ecede => 119
	i32 3955647286, ; 243: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 29
	i32 3970018735, ; 244: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 95
	i32 4015948917, ; 245: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 27
	i32 4025784931, ; 246: System.Memory => 0xeff49a63 => 17
	i32 4105002889, ; 247: Mono.Security.dll => 0xf4ad5f89 => 127
	i32 4151237749, ; 248: System.Core => 0xf76edc75 => 15
	i32 4157403133, ; 249: Xamarin.Firebase.Common.Ktx.dll => 0xf7cceffd => 78
	i32 4182413190, ; 250: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 53
	i32 4223148364, ; 251: Xamarin.Grpc.Android.dll => 0xfbb8214c => 96
	i32 4256097574, ; 252: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 39
	i32 4260525087, ; 253: System.Buffers => 0xfdf2741f => 14
	i32 4284549794, ; 254: Xamarin.Firebase.Components => 0xff610aa2 => 79
	i32 4292120959 ; 255: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 53
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [256 x i32] [
	i32 101, i32 73, i32 96, i32 51, i32 90, i32 6, i32 113, i32 61, ; 0..7
	i32 72, i32 61, i32 108, i32 35, i32 63, i32 33, i32 91, i32 48, ; 8..15
	i32 125, i32 89, i32 100, i32 46, i32 0, i32 92, i32 24, i32 19, ; 16..23
	i32 49, i32 10, i32 17, i32 71, i32 86, i32 45, i32 80, i32 5, ; 24..31
	i32 16, i32 46, i32 55, i32 74, i32 118, i32 108, i32 3, i32 92, ; 32..39
	i32 121, i32 42, i32 68, i32 30, i32 126, i32 110, i32 105, i32 97, ; 40..47
	i32 13, i32 109, i32 8, i32 85, i32 120, i32 115, i32 57, i32 90, ; 48..55
	i32 6, i32 109, i32 12, i32 49, i32 60, i32 87, i32 29, i32 52, ; 56..63
	i32 1, i32 107, i32 16, i32 75, i32 70, i32 102, i32 66, i32 30, ; 64..71
	i32 102, i32 36, i32 88, i32 62, i32 111, i32 67, i32 110, i32 27, ; 72..79
	i32 9, i32 44, i32 103, i32 77, i32 124, i32 60, i32 104, i32 38, ; 80..87
	i32 89, i32 21, i32 76, i32 120, i32 28, i32 97, i32 43, i32 123, ; 88..95
	i32 87, i32 54, i32 41, i32 18, i32 22, i32 64, i32 84, i32 80, ; 96..103
	i32 106, i32 10, i32 34, i32 91, i32 63, i32 15, i32 45, i32 54, ; 104..111
	i32 107, i32 84, i32 71, i32 76, i32 31, i32 94, i32 56, i32 106, ; 112..119
	i32 14, i32 52, i32 50, i32 22, i32 82, i32 85, i32 20, i32 47, ; 120..127
	i32 11, i32 93, i32 72, i32 98, i32 112, i32 18, i32 66, i32 78, ; 128..135
	i32 55, i32 56, i32 59, i32 83, i32 25, i32 75, i32 8, i32 116, ; 136..143
	i32 2, i32 119, i32 51, i32 86, i32 67, i32 99, i32 112, i32 41, ; 144..151
	i32 101, i32 70, i32 111, i32 64, i32 82, i32 24, i32 28, i32 81, ; 152..159
	i32 103, i32 105, i32 69, i32 114, i32 79, i32 73, i32 38, i32 23, ; 160..167
	i32 93, i32 69, i32 65, i32 99, i32 74, i32 3, i32 122, i32 5, ; 168..175
	i32 20, i32 26, i32 12, i32 88, i32 44, i32 0, i32 62, i32 48, ; 176..183
	i32 95, i32 77, i32 123, i32 1, i32 113, i32 117, i32 43, i32 114, ; 184..191
	i32 13, i32 94, i32 127, i32 34, i32 32, i32 7, i32 42, i32 117, ; 192..199
	i32 31, i32 58, i32 47, i32 9, i32 40, i32 2, i32 59, i32 21, ; 200..207
	i32 124, i32 23, i32 116, i32 83, i32 100, i32 4, i32 118, i32 37, ; 208..215
	i32 32, i32 126, i32 122, i32 81, i32 57, i32 26, i32 50, i32 4, ; 216..223
	i32 125, i32 33, i32 37, i32 115, i32 39, i32 25, i32 11, i32 35, ; 224..231
	i32 19, i32 7, i32 65, i32 58, i32 40, i32 36, i32 121, i32 68, ; 232..239
	i32 104, i32 98, i32 119, i32 29, i32 95, i32 27, i32 17, i32 127, ; 240..247
	i32 15, i32 78, i32 53, i32 96, i32 39, i32 14, i32 79, i32 53 ; 256..255
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a200af12c1e846626b8caebd926ac14c185f71ec"}
!llvm.linker.options = !{}
