; ModuleID = 'obj\Debug\130\android\marshal_methods.x86_64.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [256 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 4
	i64 210515253464952879, ; 1: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 35
	i64 232391251801502327, ; 2: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 60
	i64 233177144301842968, ; 3: Xamarin.AndroidX.Collection.Jvm.dll => 0x33c696097d9f218 => 36
	i64 295915112840604065, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 61
	i64 316157742385208084, ; 5: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 39
	i64 634308326490598313, ; 6: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 51
	i64 687654259221141486, ; 7: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 93
	i64 702024105029695270, ; 8: System.Drawing.Common => 0x9be17343c0e7726 => 115
	i64 720058930071658100, ; 9: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 47
	i64 870603111519317375, ; 10: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 10
	i64 872800313462103108, ; 11: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 44
	i64 940822596282819491, ; 12: System.Transactions => 0xd0e792aa81923a3 => 118
	i64 1000557547492888992, ; 13: Mono.Security.dll => 0xde2b1c9cba651a0 => 127
	i64 1120440138749646132, ; 14: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 84
	i64 1155807931551632357, ; 15: Xamarin.Io.PerfMark.PerfMarkApi.dll => 0x100a4130a4b6cbe5 => 103
	i64 1274338068859211160, ; 16: Xamarin.Grpc.Api => 0x11af5bb8ce1c4d98 => 97
	i64 1301485588176585670, ; 17: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 9
	i64 1315114680217950157, ; 18: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 30
	i64 1368633735297491523, ; 19: Xamarin.Firebase.Database.Collection.dll => 0x12fe5d218405e243 => 80
	i64 1392315331768750440, ; 20: Xamarin.Firebase.Auth.Interop.dll => 0x13527f6add681168 => 76
	i64 1425944114962822056, ; 21: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 123
	i64 1465843056802068477, ; 22: Xamarin.Firebase.Components.dll => 0x1457b87e6928f7fd => 79
	i64 1474586420366808421, ; 23: Xamarin.Grpc.Android.dll => 0x1476c88960941565 => 96
	i64 1518315023656898250, ; 24: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 11
	i64 1624659445732251991, ; 25: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 28
	i64 1628611045998245443, ; 26: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 53
	i64 1636321030536304333, ; 27: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 48
	i64 1731380447121279447, ; 28: Newtonsoft.Json => 0x18071957e9b889d7 => 6
	i64 1743969030606105336, ; 29: System.Memory.dll => 0x1833d297e88f2af8 => 17
	i64 1795316252682057001, ; 30: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 29
	i64 1836611346387731153, ; 31: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 60
	i64 1875917498431009007, ; 32: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 25
	i64 1956817255800234857, ; 33: Xamarin.Grpc.Android => 0x1b2802ed2e53e369 => 96
	i64 1981742497975770890, ; 34: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 52
	i64 1990714127648872464, ; 35: Xamarin.Grpc.Core.dll => 0x1ba06ff3abdcd810 => 99
	i64 2064708342624596306, ; 36: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 108
	i64 2133195048986300728, ; 37: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 6
	i64 2136356949452311481, ; 38: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 56
	i64 2165725771938924357, ; 39: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 33
	i64 2203565783020068373, ; 40: Xamarin.KotlinX.Coroutines.Core => 0x1e94a367981dde15 => 111
	i64 2262844636196693701, ; 41: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 44
	i64 2284400282711631002, ; 42: System.Web.Services => 0x1fb3d1f42fd4249a => 125
	i64 2329709569556905518, ; 43: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 50
	i64 2337758774805907496, ; 44: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 21
	i64 2343783402604882194, ; 45: Xamarin.Grpc.Stub.dll => 0x2086ca9636b86912 => 102
	i64 2470498323731680442, ; 46: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 38
	i64 2479423007379663237, ; 47: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 66
	i64 2497223385847772520, ; 48: System.Runtime => 0x22a7eb7046413568 => 22
	i64 2547086958574651984, ; 49: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 24
	i64 2592350477072141967, ; 50: System.Xml.dll => 0x23f9e10627330e8f => 23
	i64 2624866290265602282, ; 51: mscorlib.dll => 0x246d65fbde2db8ea => 5
	i64 2783046991838674048, ; 52: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 21
	i64 2787234703088983483, ; 53: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 62
	i64 2923871038697555247, ; 54: Jsr305Binding => 0x2893ad37e69ec52f => 3
	i64 2951672403965468947, ; 55: Xamarin.Firebase.Database.Collection => 0x28f67269abaf6113 => 80
	i64 3017704767998173186, ; 56: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 84
	i64 3070901203286954241, ; 57: Square.OkIO.JVM => 0x2a9e085fc23d1101 => 13
	i64 3171992396844006720, ; 58: Square.OkIO => 0x2c052e476c207d40 => 12
	i64 3289520064315143713, ; 59: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 49
	i64 3303437397778967116, ; 60: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 26
	i64 3311221304742556517, ; 61: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 20
	i64 3344514922410554693, ; 62: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 112
	i64 3364695309916733813, ; 63: Xamarin.Firebase.Common => 0x2eb1cc8eb5028175 => 77
	i64 3411255996856937470, ; 64: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 94
	i64 3427548605411023127, ; 65: Xamarin.GooglePlayServices.Auth.Api.Phone.dll => 0x2f91194bf3e8d917 => 92
	i64 3493805808809882663, ; 66: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 64
	i64 3522470458906976663, ; 67: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 63
	i64 3531994851595924923, ; 68: System.Numerics => 0x31042a9aade235bb => 19
	i64 3571415421602489686, ; 69: System.Runtime.dll => 0x319037675df7e556 => 22
	i64 3716579019761409177, ; 70: netstandard.dll => 0x3393f0ed5c8c5c99 => 116
	i64 3727469159507183293, ; 71: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 59
	i64 3768479575991719956, ; 72: Xamarin.KotlinX.Coroutines.Play.Services.dll => 0x344c5435464d1814 => 113
	i64 3966267475168208030, ; 73: System.Memory => 0x370b03412596249e => 17
	i64 4045730230152541805, ; 74: Xamarin.Grpc.Protobuf.Lite.dll => 0x38255235894d366d => 101
	i64 4201423742386704971, ; 75: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 39
	i64 4247996603072512073, ; 76: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 95
	i64 4337444564132831293, ; 77: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 8
	i64 4525561845656915374, ; 78: System.ServiceModel.Internals => 0x3ece06856b710dae => 124
	i64 4636684751163556186, ; 79: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 68
	i64 4702770163853758138, ; 80: Xamarin.Firebase.Components => 0x4143988c34cf0eba => 79
	i64 4782108999019072045, ; 81: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 32
	i64 4794310189461587505, ; 82: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 24
	i64 4795410492532947900, ; 83: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 63
	i64 4819292115633746290, ; 84: Xamarin.Firebase.AppCheck => 0x42e190a53d30b172 => 73
	i64 5203618020066742981, ; 85: Xamarin.Essentials => 0x4836f704f0e652c5 => 71
	i64 5205316157927637098, ; 86: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 55
	i64 5290215063822704973, ; 87: Xamarin.Grpc.Stub => 0x496a9e926092a14d => 102
	i64 5376510917114486089, ; 88: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 66
	i64 5408338804355907810, ; 89: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 65
	i64 5507995362134886206, ; 90: System.Core.dll => 0x4c705499688c873e => 15
	i64 5574231584441077149, ; 91: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 27
	i64 5757522595884336624, ; 92: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 37
	i64 6058153446002397952, ; 93: Xamarin.Firebase.Common.Ktx => 0x5412e2762fc81300 => 78
	i64 6118452257458269359, ; 94: Xamarin.Firebase.AppCheck.Interop.dll => 0x54e91be944fcacaf => 74
	i64 6135981624229292808, ; 95: Xamarin.Grpc.Api.dll => 0x552762c70482eb08 => 97
	i64 6183170893902868313, ; 96: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 8
	i64 6319713645133255417, ; 97: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 51
	i64 6401242110442382339, ; 98: Xamarin.Protobuf.JavaLite => 0x58d5c7c8c230a403 => 114
	i64 6401687960814735282, ; 99: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 50
	i64 6403742896930319886, ; 100: Xamarin.Firebase.Auth.dll => 0x58deaa3c7c766e0e => 75
	i64 6504860066809920875, ; 101: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 33
	i64 6548213210057960872, ; 102: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 42
	i64 6589202984700901502, ; 103: Xamarin.Google.ErrorProne.Annotations.dll => 0x5b718d34180a787e => 87
	i64 6591024623626361694, ; 104: System.Web.Services.dll => 0x5b7805f9751a1b5e => 125
	i64 6657448669945361351, ; 105: Xamarin.Google.Android.Play.Integrity => 0x5c64024aea7d73c7 => 85
	i64 6659513131007730089, ; 106: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 47
	i64 6876862101832370452, ; 107: System.Xml.Linq => 0x5f6f85a57d108914 => 126
	i64 6894844156784520562, ; 108: System.Numerics.Vectors => 0x5faf683aead1ad72 => 20
	i64 6975328107116786489, ; 109: Xamarin.Firebase.Annotations => 0x60cd57f4e07e7339 => 72
	i64 7103753931438454322, ; 110: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 46
	i64 7152933704405506614, ; 111: Xamarin.Google.Android.Play.Integrity.dll => 0x6344534e69025a36 => 85
	i64 7488575175965059935, ; 112: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 126
	i64 7625917605717986226, ; 113: Xamarin.Firebase.AppCheck.dll => 0x69d4b3a89737cbb2 => 73
	i64 7637365915383206639, ; 114: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 71
	i64 7654504624184590948, ; 115: System.Net.Http => 0x6a3a4366801b8264 => 18
	i64 7735352534559001595, ; 116: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 107
	i64 7820441508502274321, ; 117: System.Data => 0x6c87ca1e14ff8111 => 117
	i64 7836164640616011524, ; 118: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 28
	i64 7991572870742010042, ; 119: Xamarin.Firebase.Firestore.dll => 0x6ee7c52f4d39e8ba => 81
	i64 8044118961405839122, ; 120: System.ComponentModel.Composition => 0x6fa2739369944712 => 122
	i64 8083354569033831015, ; 121: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 49
	i64 8103644804370223335, ; 122: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 119
	i64 8167236081217502503, ; 123: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 2
	i64 8187640529827139739, ; 124: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 110
	i64 8242564135069360279, ; 125: MineSweeper => 0x72637868ed2f2097 => 0
	i64 8601935802264776013, ; 126: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 65
	i64 8605236455805933405, ; 127: Xamarin.Google.Android.Recaptcha.dll => 0x776bf0f6cc8dd75d => 86
	i64 8609060182490045521, ; 128: Square.OkIO.dll => 0x7779869f8b475c51 => 12
	i64 8613760304861496997, ; 129: Xamarin.CodeHaus.Mojo.AnimalSnifferAnnotations.dll => 0x778a395c0fa146a5 => 70
	i64 8626175481042262068, ; 130: Java.Interop => 0x77b654e585b55834 => 2
	i64 8684531736582871431, ; 131: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 121
	i64 8853378295825400934, ; 132: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 106
	i64 8951477988056063522, ; 133: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 58
	i64 9031035476476434958, ; 134: Xamarin.KotlinX.Coroutines.Core.dll => 0x7d54aeead9541a0e => 111
	i64 9113579748781016974, ; 135: Xamarin.Firebase.Storage.dll => 0x7e79f07ee649478e => 83
	i64 9324707631942237306, ; 136: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 29
	i64 9490522350195345034, ; 137: Xamarin.Google.Android.Recaptcha => 0x83b51bcb684c868a => 86
	i64 9662334977499516867, ; 138: System.Numerics.dll => 0x8617827802b0cfc3 => 19
	i64 9678050649315576968, ; 139: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 38
	i64 9808709177481450983, ; 140: Mono.Android.dll => 0x881f890734e555e7 => 4
	i64 9825649861376906464, ; 141: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 37
	i64 9834056768316610435, ; 142: System.Transactions.dll => 0x8879968718899783 => 118
	i64 9875200773399460291, ; 143: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 93
	i64 9998632235833408227, ; 144: Mono.Security => 0x8ac2470b209ebae3 => 127
	i64 10038780035334861115, ; 145: System.Net.Http.dll => 0x8b50e941206af13b => 18
	i64 10071983904436292605, ; 146: Xamarin.CodeHaus.Mojo.AnimalSnifferAnnotations => 0x8bc6dfff57608bfd => 70
	i64 10167561595017141208, ; 147: Xamarin.GoogleAndroid.Annotations.dll => 0x8d1a6f668ee69bd8 => 91
	i64 10226222362177979215, ; 148: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 108
	i64 10229024438826829339, ; 149: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 42
	i64 10321854143672141184, ; 150: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 105
	i64 10376576884623852283, ; 151: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 64
	i64 10406448008575299332, ; 152: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 112
	i64 10430153318873392755, ; 153: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 40
	i64 10847732767863316357, ; 154: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 30
	i64 10857315922431607327, ; 155: Xamarin.Firebase.ProtoliteWellKnownTypes => 0x96acef4e92ba821f => 82
	i64 10966933586012635777, ; 156: Xamarin.Grpc.OkHttp.dll => 0x98325ffdbd958281 => 100
	i64 11019817191295005410, ; 157: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 27
	i64 11023048688141570732, ; 158: System.Core => 0x98f9bc61168392ac => 15
	i64 11037814507248023548, ; 159: System.Xml => 0x992e31d0412bf7fc => 23
	i64 11071824625609515081, ; 160: Xamarin.Google.ErrorProne.Annotations => 0x99a705d600e0a049 => 87
	i64 11072526564452562534, ; 161: Square.OkIO.JVM.dll => 0x99a9843ee0457666 => 13
	i64 11136029745144976707, ; 162: Jsr305Binding.dll => 0x9a8b200d4f8cd543 => 3
	i64 11162124722117608902, ; 163: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 69
	i64 11299661109949763898, ; 164: Xamarin.AndroidX.Collection.Jvm => 0x9cd075e94cda113a => 36
	i64 11340910727871153756, ; 165: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 41
	i64 11361951459766490322, ; 166: Xamarin.GoogleAndroid.Annotations => 0x9dadc2a78a9cd4d2 => 91
	i64 11376351552967644903, ; 167: Xamarin.Firebase.Annotations.dll => 0x9de0eb76829996e7 => 72
	i64 11392833485892708388, ; 168: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 57
	i64 11496466075493495264, ; 169: Xamarin.Grpc.Context.dll => 0x9f8ba6fc1a1e71e0 => 98
	i64 11529969570048099689, ; 170: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 69
	i64 11543422055205009205, ; 171: Xamarin.Firebase.Firestore => 0xa032793314e77735 => 81
	i64 11580057168383206117, ; 172: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 25
	i64 11591352189662810718, ; 173: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 62
	i64 11597940890313164233, ; 174: netstandard => 0xa0f429ca8d1805c9 => 116
	i64 11672361001936329215, ; 175: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 46
	i64 11739066727115742305, ; 176: SQLite-net.dll => 0xa2e98afdf8575c61 => 7
	i64 11806260347154423189, ; 177: SQLite-net => 0xa3d8433bc5eb5d95 => 7
	i64 11864794479965678424, ; 178: Xamarin.Protobuf.JavaLite.dll => 0xa4a837b7975eab58 => 114
	i64 12102847907131387746, ; 179: System.Buffers => 0xa7f5f40c43256f62 => 14
	i64 12137774235383566651, ; 180: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 67
	i64 12279246230491828964, ; 181: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 11
	i64 12336928085371509187, ; 182: Xamarin.GooglePlayServices.Auth.Api.Phone => 0xab3592bad41bd9c3 => 92
	i64 12346958216201575315, ; 183: Xamarin.JavaX.Inject.dll => 0xab593514a5491b93 => 104
	i64 12451044538927396471, ; 184: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 45
	i64 12466513435562512481, ; 185: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 54
	i64 12487638416075308985, ; 186: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 43
	i64 12538491095302438457, ; 187: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 34
	i64 12550732019250633519, ; 188: System.IO.Compression => 0xae2d28465e8e1b2f => 120
	i64 12700543734426720211, ; 189: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 35
	i64 12828192437253469131, ; 190: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 109
	i64 12963446364377008305, ; 191: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 115
	i64 13084382143907087733, ; 192: Xamarin.Grpc.Context => 0xb595103c610bc575 => 98
	i64 13370592475155966277, ; 193: System.Runtime.Serialization => 0xb98de304062ea945 => 123
	i64 13401370062847626945, ; 194: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 67
	i64 13402939433517888790, ; 195: Xamarin.Google.Guava.FailureAccess => 0xba00ce6728e8b516 => 89
	i64 13454009404024712428, ; 196: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 90
	i64 13465488254036897740, ; 197: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 107
	i64 13491513212026656886, ; 198: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 31
	i64 13572454107664307259, ; 199: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 59
	i64 13609095008681508810, ; 200: Xamarin.Grpc.Protobuf.Lite => 0xbcdd37ce6b00bfca => 101
	i64 13647894001087880694, ; 201: System.Data.dll => 0xbd670f48cb071df6 => 117
	i64 13761131323945450492, ; 202: Xamarin.Firebase.Storage => 0xbef95c078f44fbfc => 83
	i64 13807020823704499900, ; 203: Xamarin.Firebase.Common.Ktx.dll => 0xbf9c64495353f6bc => 78
	i64 13828521679616088467, ; 204: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 106
	i64 13865727802090930648, ; 205: Xamarin.Google.Guava.dll => 0xc06cf5f8e3e341d8 => 88
	i64 13959074834287824816, ; 206: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 45
	i64 13975254687929967048, ; 207: Xamarin.Google.Guava => 0xc1f2141837ada1c8 => 88
	i64 14124974489674258913, ; 208: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 34
	i64 14165531176311179688, ; 209: Xamarin.Firebase.Auth => 0xc496138d7abfc9a8 => 75
	i64 14172845254133543601, ; 210: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 56
	i64 14261073672896646636, ; 211: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 57
	i64 14382082037123372364, ; 212: Xamarin.Firebase.Auth.Interop => 0xc7976b69c943d54c => 76
	i64 14524915121004231475, ; 213: Xamarin.JavaX.Inject => 0xc992dd58a4283b33 => 104
	i64 14644440854989303794, ; 214: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 55
	i64 14671188939680189912, ; 215: Xamarin.Grpc.Core => 0xcb9a889bfe470dd8 => 99
	i64 14698606024688292729, ; 216: Xamarin.Io.PerfMark.PerfMarkApi => 0xcbfbf04d8af65379 => 103
	i64 14789919016435397935, ; 217: Xamarin.Firebase.Common.dll => 0xcd4058fc2f6d352f => 77
	i64 14792063746108907174, ; 218: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 90
	i64 14852515768018889994, ; 219: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 41
	i64 14889905118082851278, ; 220: GoogleGson.dll => 0xcea391d0969961ce => 1
	i64 14987728460634540364, ; 221: System.IO.Compression.dll => 0xcfff1ba06622494c => 120
	i64 14988210264188246988, ; 222: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 43
	i64 15099396616243600100, ; 223: Xamarin.KotlinX.Coroutines.Play.Services => 0xd18bd538f1ef5ae4 => 113
	i64 15150743910298169673, ; 224: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 58
	i64 15279429628684179188, ; 225: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 110
	i64 15370334346939861994, ; 226: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 40
	i64 15582737692548360875, ; 227: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 53
	i64 15609085926864131306, ; 228: System.dll => 0xd89e9cf3334914ea => 16
	i64 15613456987655481696, ; 229: MineSweeper.dll => 0xd8ae2468190ba960 => 0
	i64 15777549416145007739, ; 230: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 61
	i64 15788897513097211459, ; 231: Xamarin.Firebase.ProtoliteWellKnownTypes.dll => 0xdb1d6ea28f352e43 => 82
	i64 15930129725311349754, ; 232: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 95
	i64 16154507427712707110, ; 233: System => 0xe03056ea4e39aa26 => 16
	i64 16303230644352379770, ; 234: Xamarin.Grpc.OkHttp => 0xe240b5e48fe2eb7a => 100
	i64 16423015068819898779, ; 235: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 109
	i64 16565028646146589191, ; 236: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 122
	i64 16579050217386591297, ; 237: Xamarin.Google.Guava.FailureAccess.dll => 0xe6149e5548b0c441 => 89
	i64 16755018182064898362, ; 238: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 9
	i64 16822611501064131242, ; 239: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 119
	i64 16833383113903931215, ; 240: mscorlib => 0xe99c30c1484d7f4f => 5
	i64 17024911836938395553, ; 241: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 26
	i64 17037200463775726619, ; 242: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 48
	i64 17522591619082469157, ; 243: GoogleGson => 0xf32cc03d27a5bf25 => 1
	i64 17544493274320527064, ; 244: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 32
	i64 17605100189928655442, ; 245: Xamarin.Firebase.AppCheck.Interop => 0xf451e158cfdc0a52 => 74
	i64 17704177640604968747, ; 246: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 54
	i64 17710060891934109755, ; 247: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 52
	i64 17838668724098252521, ; 248: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 14
	i64 17891337867145587222, ; 249: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 105
	i64 17928294245072900555, ; 250: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 121
	i64 17986907704309214542, ; 251: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 94
	i64 18116111925905154859, ; 252: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 31
	i64 18129453464017766560, ; 253: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 124
	i64 18370042311372477656, ; 254: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 10
	i64 18380184030268848184 ; 255: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 68
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [256 x i32] [
	i32 4, i32 35, i32 60, i32 36, i32 61, i32 39, i32 51, i32 93, ; 0..7
	i32 115, i32 47, i32 10, i32 44, i32 118, i32 127, i32 84, i32 103, ; 8..15
	i32 97, i32 9, i32 30, i32 80, i32 76, i32 123, i32 79, i32 96, ; 16..23
	i32 11, i32 28, i32 53, i32 48, i32 6, i32 17, i32 29, i32 60, ; 24..31
	i32 25, i32 96, i32 52, i32 99, i32 108, i32 6, i32 56, i32 33, ; 32..39
	i32 111, i32 44, i32 125, i32 50, i32 21, i32 102, i32 38, i32 66, ; 40..47
	i32 22, i32 24, i32 23, i32 5, i32 21, i32 62, i32 3, i32 80, ; 48..55
	i32 84, i32 13, i32 12, i32 49, i32 26, i32 20, i32 112, i32 77, ; 56..63
	i32 94, i32 92, i32 64, i32 63, i32 19, i32 22, i32 116, i32 59, ; 64..71
	i32 113, i32 17, i32 101, i32 39, i32 95, i32 8, i32 124, i32 68, ; 72..79
	i32 79, i32 32, i32 24, i32 63, i32 73, i32 71, i32 55, i32 102, ; 80..87
	i32 66, i32 65, i32 15, i32 27, i32 37, i32 78, i32 74, i32 97, ; 88..95
	i32 8, i32 51, i32 114, i32 50, i32 75, i32 33, i32 42, i32 87, ; 96..103
	i32 125, i32 85, i32 47, i32 126, i32 20, i32 72, i32 46, i32 85, ; 104..111
	i32 126, i32 73, i32 71, i32 18, i32 107, i32 117, i32 28, i32 81, ; 112..119
	i32 122, i32 49, i32 119, i32 2, i32 110, i32 0, i32 65, i32 86, ; 120..127
	i32 12, i32 70, i32 2, i32 121, i32 106, i32 58, i32 111, i32 83, ; 128..135
	i32 29, i32 86, i32 19, i32 38, i32 4, i32 37, i32 118, i32 93, ; 136..143
	i32 127, i32 18, i32 70, i32 91, i32 108, i32 42, i32 105, i32 64, ; 144..151
	i32 112, i32 40, i32 30, i32 82, i32 100, i32 27, i32 15, i32 23, ; 152..159
	i32 87, i32 13, i32 3, i32 69, i32 36, i32 41, i32 91, i32 72, ; 160..167
	i32 57, i32 98, i32 69, i32 81, i32 25, i32 62, i32 116, i32 46, ; 168..175
	i32 7, i32 7, i32 114, i32 14, i32 67, i32 11, i32 92, i32 104, ; 176..183
	i32 45, i32 54, i32 43, i32 34, i32 120, i32 35, i32 109, i32 115, ; 184..191
	i32 98, i32 123, i32 67, i32 89, i32 90, i32 107, i32 31, i32 59, ; 192..199
	i32 101, i32 117, i32 83, i32 78, i32 106, i32 88, i32 45, i32 88, ; 200..207
	i32 34, i32 75, i32 56, i32 57, i32 76, i32 104, i32 55, i32 99, ; 208..215
	i32 103, i32 77, i32 90, i32 41, i32 1, i32 120, i32 43, i32 113, ; 216..223
	i32 58, i32 110, i32 40, i32 53, i32 16, i32 0, i32 61, i32 82, ; 224..231
	i32 95, i32 16, i32 100, i32 109, i32 122, i32 89, i32 9, i32 119, ; 232..239
	i32 5, i32 26, i32 48, i32 1, i32 32, i32 74, i32 54, i32 52, ; 240..247
	i32 14, i32 105, i32 121, i32 94, i32 31, i32 124, i32 10, i32 68 ; 256..255
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ a200af12c1e846626b8caebd926ac14c185f71ec"}
!llvm.linker.options = !{}
