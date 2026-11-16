| Description                                         | TestDataSize | Mean         | Error        | StdDev        | Median       | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|-------------:|--------------:|-------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     661.2 ns |      0.65 ns |       0.55 ns |     661.2 ns |   3,988 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     886.4 ns |      1.25 ns |       1.04 ns |     886.3 ns |   5,062 B |         - |
|                                                     |              |              |              |               |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     697.0 ns |      1.27 ns |       1.13 ns |     697.0 ns |   3,996 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     935.3 ns |      1.52 ns |       1.35 ns |     935.2 ns |   5,062 B |         - |
|                                                     |              |              |              |               |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,274.0 ns |     10.81 ns |       9.59 ns |   4,270.9 ns |   3,988 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,772.3 ns |     12.68 ns |      10.59 ns |   5,769.9 ns |   5,062 B |         - |
|                                                     |              |              |              |               |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,266.2 ns |      5.05 ns |       4.22 ns |   4,265.5 ns |   3,987 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,784.9 ns |     14.15 ns |      12.55 ns |   5,786.7 ns |   5,062 B |         - |
|                                                     |              |              |              |               |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  33,087.5 ns |     55.28 ns |      43.16 ns |  33,085.8 ns |   4,004 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  48,781.2 ns |    996.68 ns |   2,891.54 ns |  49,020.9 ns |   5,071 B |         - |
|                                                     |              |              |              |               |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 529,743.4 ns |  2,466.86 ns |   2,307.51 ns | 528,615.3 ns |   3,955 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 926,839.6 ns | 64,018.00 ns | 188,758.53 ns | 843,336.5 ns |   5,060 B |         - |