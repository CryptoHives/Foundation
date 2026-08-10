| Description                                       | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      90.78 ns |     0.144 ns |   0.127 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |      96.62 ns |     0.036 ns |   0.030 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     126.64 ns |     0.381 ns |   0.318 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |     176.86 ns |     1.874 ns |   1.753 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     596.85 ns |     1.770 ns |   1.655 ns |    1120 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     169.41 ns |     0.077 ns |   0.072 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     187.84 ns |     0.069 ns |   0.061 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     231.65 ns |     0.200 ns |   0.187 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 137B         |     358.84 ns |     3.634 ns |   3.400 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |   1,106.53 ns |     5.260 ns |   4.920 ns |    1136 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     652.69 ns |     0.420 ns |   0.372 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     740.11 ns |     0.509 ns |   0.476 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     871.04 ns |     0.450 ns |   0.399 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |   1,482.17 ns |     4.027 ns |   3.767 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,812.72 ns |    14.799 ns |  13.843 ns |    2016 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     733.22 ns |     0.218 ns |   0.204 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |     833.15 ns |     0.484 ns |   0.452 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     975.35 ns |     0.634 ns |   0.593 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |   1,669.58 ns |     4.914 ns |   4.356 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   4,330.46 ns |    12.396 ns |  11.595 ns |    2024 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,166.35 ns |     1.854 ns |   1.643 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   5,899.13 ns |     4.945 ns |   4.626 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   6,800.68 ns |     1.037 ns |   0.970 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |  11,948.40 ns |     4.705 ns |   4.401 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  29,477.76 ns |    58.843 ns |  55.042 ns |    9184 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  82,555.48 ns |    72.544 ns |  60.578 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |  94,428.75 ns |    88.644 ns |  82.918 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        | 108,437.98 ns |    41.123 ns |  38.467 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        | 191,429.31 ns |    22.075 ns |  17.234 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 476,149.05 ns | 1,068.858 ns | 999.810 ns |  132092 B |