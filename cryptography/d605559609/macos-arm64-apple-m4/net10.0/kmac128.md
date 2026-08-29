| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     488.6 ns |   0.74 ns |   0.65 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,031.2 ns |   2.36 ns |   2.09 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     495.6 ns |   3.77 ns |   3.53 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,047.0 ns |   3.09 ns |   2.73 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,418.4 ns |   1.03 ns |   0.80 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   1,992.0 ns |   6.86 ns |   6.42 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,396.4 ns |  10.76 ns |   8.98 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   1,970.3 ns |   8.19 ns |   7.66 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,748.6 ns |   4.82 ns |   4.27 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,336.9 ns |  26.84 ns |  23.79 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 117,148.1 ns | 134.66 ns | 119.37 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 121,603.1 ns | 375.38 ns | 332.77 ns |     256 B |