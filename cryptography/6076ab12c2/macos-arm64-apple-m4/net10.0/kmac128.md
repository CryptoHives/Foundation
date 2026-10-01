| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     483.7 ns |   0.66 ns |   0.59 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,034.3 ns |   4.29 ns |   4.01 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     483.0 ns |   0.53 ns |   0.47 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,031.5 ns |   2.84 ns |   2.52 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,374.3 ns |   1.21 ns |   1.13 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   1,960.3 ns |   7.03 ns |   5.87 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,387.5 ns |   1.78 ns |   1.58 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   1,958.1 ns |   8.84 ns |   7.38 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,603.5 ns |   6.36 ns |   5.64 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,386.6 ns |  49.27 ns |  43.68 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 118,693.5 ns |  89.20 ns |  83.43 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 122,377.8 ns | 741.11 ns | 618.86 ns |     256 B |