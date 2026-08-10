| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      92.09 ns |     0.259 ns |     0.242 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |      97.18 ns |     0.215 ns |     0.202 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     129.92 ns |     0.126 ns |     0.117 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |     175.30 ns |     2.006 ns |     1.876 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     621.73 ns |     1.524 ns |     1.351 ns |    1216 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     171.31 ns |     0.096 ns |     0.090 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     188.72 ns |     0.303 ns |     0.284 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     236.26 ns |     0.502 ns |     0.470 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 137B         |     360.80 ns |     1.869 ns |     1.657 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |   1,144.41 ns |     3.159 ns |     2.955 ns |    1232 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     658.49 ns |     0.574 ns |     0.537 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     746.00 ns |     0.339 ns |     0.317 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     879.16 ns |     1.465 ns |     1.370 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |   1,489.77 ns |     5.494 ns |     5.139 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,893.39 ns |    19.557 ns |    18.293 ns |    2112 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     740.72 ns |     1.398 ns |     1.308 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |     839.27 ns |     1.870 ns |     1.750 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     985.11 ns |     0.581 ns |     0.543 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |   1,677.80 ns |     4.457 ns |     4.169 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   4,439.10 ns |    13.027 ns |    12.185 ns |    2120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,203.78 ns |     2.542 ns |     2.378 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   5,948.90 ns |    13.327 ns |    12.466 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   6,833.81 ns |    16.908 ns |    15.815 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |  12,038.24 ns |    19.340 ns |    17.144 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  30,048.48 ns |    78.075 ns |    69.212 ns |    9280 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  82,899.05 ns |   235.891 ns |   220.653 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |  95,139.78 ns |   290.912 ns |   272.119 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        | 109,230.32 ns |    82.708 ns |    77.365 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        | 192,974.80 ns |   452.999 ns |   423.736 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 484,765.33 ns | 1,307.826 ns | 1,223.341 ns |  132188 B |