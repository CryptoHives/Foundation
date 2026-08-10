| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     659.6 ns |   1.91 ns |   1.78 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,058.5 ns |   6.66 ns |   5.90 ns |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,034.5 ns |   4.24 ns |   3.76 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     659.7 ns |   2.28 ns |   2.02 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,052.5 ns |   2.72 ns |   2.41 ns |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,036.5 ns |   4.66 ns |   4.36 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,886.0 ns |   3.89 ns |   3.64 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,587.2 ns |   3.94 ns |   3.29 ns |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   3,933.9 ns |   8.04 ns |   7.12 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,885.8 ns |   3.64 ns |   3.04 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,593.8 ns |   6.43 ns |   5.70 ns |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   3,920.9 ns |   8.83 ns |   7.37 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  10,493.7 ns |  30.39 ns |  26.94 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  13,444.2 ns |  44.80 ns |  39.72 ns |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  17,310.4 ns |  30.05 ns |  26.64 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 160,195.9 ns | 269.98 ns | 239.33 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 231,269.5 ns | 823.16 ns | 729.71 ns |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 248,821.0 ns | 209.40 ns | 185.63 ns |     256 B |