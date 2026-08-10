| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      91.55 ns |     0.171 ns |     0.160 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |      95.93 ns |     0.190 ns |     0.178 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     128.89 ns |     0.152 ns |     0.142 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |     173.92 ns |     2.717 ns |     2.542 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     605.17 ns |     2.472 ns |     2.312 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     169.47 ns |     0.351 ns |     0.311 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     186.74 ns |     0.490 ns |     0.458 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     234.33 ns |     0.205 ns |     0.192 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 137B         |     360.09 ns |     3.530 ns |     3.129 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |   1,103.89 ns |     5.406 ns |     5.057 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     648.39 ns |     1.807 ns |     1.691 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     729.54 ns |     3.572 ns |     3.167 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     874.16 ns |     0.731 ns |     0.648 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |   1,481.04 ns |     2.863 ns |     2.678 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,749.92 ns |    13.458 ns |    12.589 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     729.22 ns |     1.586 ns |     1.484 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |     826.18 ns |     2.582 ns |     2.415 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     980.23 ns |     0.948 ns |     0.887 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |   1,670.54 ns |     4.952 ns |     3.866 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   4,271.15 ns |    29.610 ns |    24.726 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,128.38 ns |    11.411 ns |    10.674 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   5,813.63 ns |    15.115 ns |    14.139 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   6,801.93 ns |     6.883 ns |     6.438 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |  11,991.66 ns |     9.642 ns |     8.052 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  29,056.48 ns |   249.171 ns |   208.069 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  82,166.78 ns |   218.132 ns |   204.040 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |  92,997.12 ns |   208.667 ns |   174.246 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        | 108,532.62 ns |   316.635 ns |   247.208 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        | 191,894.21 ns |   505.710 ns |   422.291 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 469,601.99 ns | 1,733.368 ns | 1,621.394 ns |  132188 B |