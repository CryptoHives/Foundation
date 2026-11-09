| Description                                        | TestDataSize | Mean         | Error        | StdDev       | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     883.1 ns |     10.74 ns |     10.05 ns |   4,016 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |   1,076.6 ns |     16.73 ns |     15.65 ns |   4,942 B |         - |
|                                                    |              |              |              |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     925.3 ns |     16.91 ns |     15.82 ns |   4,032 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |   1,098.4 ns |      1.93 ns |      1.71 ns |   4,942 B |         - |
|                                                    |              |              |              |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   5,670.0 ns |     10.36 ns |      9.18 ns |   4,016 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,841.8 ns |      8.34 ns |      6.51 ns |   4,942 B |         - |
|                                                    |              |              |              |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   5,672.0 ns |      8.39 ns |      7.44 ns |   4,032 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,841.9 ns |     10.86 ns |      9.62 ns |   4,929 B |         - |
|                                                    |              |              |              |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  44,888.3 ns |    742.82 ns |    694.83 ns |   4,028 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  53,976.2 ns |    983.18 ns |    919.67 ns |   4,942 B |         - |
|                                                    |              |              |              |              |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 700,893.2 ns |  2,019.49 ns |  1,889.03 ns |   3,975 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 869,650.3 ns | 13,827.18 ns | 12,933.95 ns |   4,942 B |         - |