| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      92.76 ns |     1.336 ns |     1.250 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |      97.88 ns |     1.211 ns |     1.133 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     127.00 ns |     0.230 ns |     0.180 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |     172.57 ns |     2.408 ns |     2.253 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     623.53 ns |     1.990 ns |     1.553 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     172.12 ns |     2.481 ns |     2.321 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     190.19 ns |     2.531 ns |     2.368 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     232.33 ns |     0.205 ns |     0.172 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 137B         |     361.35 ns |     5.475 ns |     5.122 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |   1,143.04 ns |     3.756 ns |     2.933 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     657.78 ns |     5.824 ns |     4.547 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     747.96 ns |    10.011 ns |     8.874 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     882.54 ns |    12.609 ns |    11.794 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |   1,496.31 ns |    18.140 ns |    16.968 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,882.74 ns |    16.754 ns |    13.080 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     742.39 ns |     8.925 ns |     7.912 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |     845.31 ns |    10.526 ns |     9.846 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     978.58 ns |     2.764 ns |     2.158 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |   1,686.12 ns |    19.966 ns |    18.677 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   4,408.09 ns |    15.748 ns |    12.295 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,229.30 ns |    76.700 ns |    71.745 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   5,981.94 ns |    79.328 ns |    74.203 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   6,882.29 ns |    92.485 ns |    86.511 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |  12,099.97 ns |   131.309 ns |   122.827 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  30,239.01 ns |   422.905 ns |   395.585 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  83,344.70 ns | 1,029.161 ns |   912.325 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |  95,657.90 ns | 1,175.136 ns | 1,099.223 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        | 110,025.46 ns | 1,735.379 ns | 1,623.275 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        | 193,927.57 ns | 2,057.342 ns | 1,924.439 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 487,642.87 ns | 6,501.271 ns | 6,081.293 ns |  132188 B |