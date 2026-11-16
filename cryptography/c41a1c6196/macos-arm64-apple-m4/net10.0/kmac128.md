| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     494.1 ns |   1.36 ns |   1.27 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,044.2 ns |   2.54 ns |   2.25 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     494.4 ns |   0.98 ns |   0.92 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,044.6 ns |   3.33 ns |   3.12 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,400.0 ns |   4.86 ns |   4.54 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   1,982.8 ns |   6.61 ns |   6.18 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,398.6 ns |   2.37 ns |   2.22 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   1,978.7 ns |   9.05 ns |   8.46 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,719.0 ns |  26.81 ns |  25.08 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,474.5 ns |  25.31 ns |  22.43 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 118,766.3 ns | 308.99 ns | 289.03 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 122,676.9 ns | 618.90 ns | 548.64 ns |     256 B |