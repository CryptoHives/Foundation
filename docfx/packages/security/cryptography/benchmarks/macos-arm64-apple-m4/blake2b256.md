| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      90.21 ns |     0.287 ns |     0.268 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |      94.42 ns |     0.421 ns |     0.373 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     126.65 ns |     0.173 ns |     0.154 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |     175.06 ns |     1.923 ns |     1.798 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     580.56 ns |     2.447 ns |     2.289 ns |    1120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     167.61 ns |     0.536 ns |     0.501 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     181.89 ns |     0.816 ns |     0.764 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     231.56 ns |     0.295 ns |     0.276 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 137B         |     359.77 ns |     3.134 ns |     2.931 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |   1,071.16 ns |     6.749 ns |     6.313 ns |    1136 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     640.41 ns |     2.543 ns |     2.378 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     718.15 ns |     1.917 ns |     1.793 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     869.99 ns |     0.782 ns |     0.693 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |   1,482.78 ns |     3.662 ns |     3.246 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,703.12 ns |    10.129 ns |     9.474 ns |    2016 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     723.58 ns |     2.977 ns |     2.784 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |     809.98 ns |     2.489 ns |     2.328 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     974.48 ns |     1.068 ns |     0.999 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |   1,671.57 ns |     3.627 ns |     3.215 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   4,224.25 ns |    41.654 ns |    36.926 ns |    2024 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,088.96 ns |    20.869 ns |    19.521 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   5,758.37 ns |    20.977 ns |    19.622 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   6,794.02 ns |     5.772 ns |     5.117 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |  11,941.81 ns |     4.603 ns |     3.843 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  28,735.68 ns |   107.900 ns |   100.929 ns |    9184 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  81,489.19 ns |   296.898 ns |   277.718 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |  92,497.55 ns |   356.361 ns |   333.340 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        | 108,355.99 ns |    52.738 ns |    44.039 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        | 191,376.36 ns |    68.707 ns |    57.373 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 465,280.36 ns | 1,665.225 ns | 1,557.652 ns |  132092 B |