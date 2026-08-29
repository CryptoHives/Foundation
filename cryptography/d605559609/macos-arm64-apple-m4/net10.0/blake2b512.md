| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      91.82 ns |     0.229 ns |     0.214 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |      97.21 ns |     0.025 ns |     0.021 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     126.41 ns |     0.321 ns |     0.268 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |     185.13 ns |     0.652 ns |     0.578 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     692.39 ns |     1.431 ns |     1.339 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     170.25 ns |     0.110 ns |     0.092 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     188.10 ns |     0.332 ns |     0.311 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     231.18 ns |     0.226 ns |     0.200 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 137B         |     372.03 ns |     3.427 ns |     3.206 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |   1,287.10 ns |     0.817 ns |     0.638 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     653.03 ns |     0.295 ns |     0.246 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     741.42 ns |     0.355 ns |     0.297 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     871.56 ns |     0.900 ns |     0.752 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |   1,486.57 ns |    10.557 ns |     9.358 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   4,430.44 ns |     1.830 ns |     1.429 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     735.38 ns |     1.236 ns |     1.096 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |     836.88 ns |     0.512 ns |     0.427 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     976.78 ns |     0.872 ns |     0.773 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |   1,676.70 ns |    16.850 ns |    14.071 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   5,036.85 ns |     4.132 ns |     3.663 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,172.07 ns |     1.092 ns |     0.912 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   5,912.07 ns |     1.335 ns |     1.115 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   6,802.54 ns |     3.064 ns |     2.559 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |  12,196.66 ns |   140.282 ns |   124.356 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  34,190.65 ns |    22.954 ns |    19.167 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  82,591.97 ns |    14.659 ns |    12.241 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |  94,587.93 ns |    23.974 ns |    18.717 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        | 108,670.26 ns |   156.394 ns |   122.102 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        | 192,898.28 ns |   899.097 ns |   797.026 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 553,971.29 ns | 1,140.457 ns | 1,010.986 ns |  132188 B |