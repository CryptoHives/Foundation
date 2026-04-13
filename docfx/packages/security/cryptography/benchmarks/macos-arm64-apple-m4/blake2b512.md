| Description                                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |      91.64 ns |     0.135 ns |     0.126 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     103.10 ns |     0.110 ns |     0.103 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     128.97 ns |     0.170 ns |     0.159 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128B         |     179.50 ns |     0.042 ns |     0.038 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     612.22 ns |     2.841 ns |     2.657 ns |    1216 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     170.14 ns |     0.046 ns |     0.043 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     196.01 ns |     0.199 ns |     0.186 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     234.62 ns |     0.173 ns |     0.162 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 137B         |     363.20 ns |     0.054 ns |     0.045 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |   1,128.63 ns |     5.540 ns |     5.182 ns |    1232 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     653.70 ns |     0.208 ns |     0.173 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |     749.44 ns |     0.983 ns |     0.920 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     873.07 ns |     0.710 ns |     0.664 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1KB          |   1,462.97 ns |     0.647 ns |     0.505 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,807.56 ns |    13.368 ns |    12.504 ns |    2112 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     734.98 ns |     0.256 ns |     0.240 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |     844.15 ns |     1.155 ns |     1.081 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     978.13 ns |     0.693 ns |     0.648 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 1025B        |   1,646.19 ns |     0.185 ns |     0.164 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   4,324.14 ns |    16.944 ns |    15.850 ns |    2120 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,160.05 ns |     3.151 ns |     2.947 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |   5,931.60 ns |     8.931 ns |     8.354 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   6,801.45 ns |     4.541 ns |     4.248 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 8KB          |  11,729.50 ns |     3.135 ns |     2.779 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  29,336.98 ns |    93.761 ns |    87.704 ns |    9280 B |
|                                                         |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  82,504.05 ns |    37.307 ns |    33.072 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        |  94,806.29 ns |   175.744 ns |   164.391 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        | 108,483.94 ns |    36.782 ns |    32.606 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Neon)       | 128KB        | 187,807.33 ns |    37.139 ns |    34.740 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 475,842.57 ns | 1,711.904 ns | 1,601.316 ns |  132188 B |