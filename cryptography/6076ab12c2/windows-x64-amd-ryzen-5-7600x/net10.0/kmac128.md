| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     737.7 ns |   1.36 ns |   1.20 ns |   8,177 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,144.6 ns |   3.22 ns |   3.02 ns |   7,255 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,436.1 ns |   4.28 ns |   4.00 ns |  16,661 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     737.7 ns |   1.01 ns |   0.89 ns |   8,167 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,147.5 ns |   2.02 ns |   1.58 ns |   7,252 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,258.8 ns |   3.76 ns |   3.52 ns |  16,650 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   2,115.0 ns |   7.14 ns |   6.68 ns |   8,160 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,846.4 ns |   8.44 ns |   7.48 ns |   7,251 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   4,359.1 ns |   8.26 ns |   7.32 ns |  16,693 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   2,118.0 ns |   5.35 ns |   4.74 ns |   8,157 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,869.2 ns |   5.60 ns |   4.67 ns |   7,538 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   4,366.6 ns |  14.50 ns |  13.56 ns |  16,693 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  11,786.5 ns |  16.28 ns |  13.60 ns |   8,173 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  14,781.4 ns |  24.95 ns |  22.11 ns |   7,447 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  19,304.8 ns |  41.90 ns |  39.19 ns |  21,246 B |     256 B |
|                                                |              |              |           |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 179,959.1 ns | 309.51 ns | 289.52 ns |   8,161 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 257,490.0 ns | 639.03 ns | 566.48 ns |   7,800 B |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 280,584.3 ns | 847.75 ns | 792.98 ns |  21,387 B |     256 B |