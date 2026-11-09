| Description                                         | TestDataSize | Mean         | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     854.4 ns |      1.25 ns |      1.10 ns |   4,006 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |   1,057.5 ns |      2.00 ns |      1.78 ns |   5,085 B |         - |
|                                                     |              |              |              |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     914.6 ns |     14.94 ns |     13.97 ns |   4,018 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |   1,140.8 ns |     20.43 ns |     19.11 ns |   5,085 B |         - |
|                                                     |              |              |              |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   5,832.4 ns |     92.43 ns |     86.46 ns |   4,006 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   7,116.2 ns |    119.36 ns |    111.65 ns |   5,085 B |         - |
|                                                     |              |              |              |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   5,870.8 ns |     49.83 ns |     46.61 ns |   4,018 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   7,152.3 ns |    110.24 ns |    103.12 ns |   5,085 B |         - |
|                                                     |              |              |              |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  45,031.5 ns |    738.20 ns |    690.51 ns |   4,022 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  55,416.9 ns |    719.69 ns |    673.20 ns |   5,081 B |         - |
|                                                     |              |              |              |              |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 719,936.1 ns | 12,466.16 ns | 11,660.85 ns |   3,973 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 883,570.0 ns | 14,917.47 ns | 13,953.81 ns |   5,092 B |         - |