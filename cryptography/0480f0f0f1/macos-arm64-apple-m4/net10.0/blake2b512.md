| Description                                             | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128B         |      92.11 ns |   0.136 ns |   0.127 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128B         |     102.01 ns |   0.104 ns |   0.092 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128B         |     129.33 ns |   0.406 ns |   0.359 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128B         |     629.28 ns |   1.149 ns |   1.075 ns |    1216 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 137B         |     171.80 ns |   0.199 ns |   0.186 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 137B         |     192.53 ns |   0.172 ns |   0.161 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 137B         |     235.89 ns |   0.302 ns |   0.267 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 137B         |   1,146.74 ns |   1.403 ns |   1.312 ns |    1232 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1KB          |     657.05 ns |   0.782 ns |   0.693 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1KB          |     748.99 ns |   0.587 ns |   0.490 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1KB          |     879.71 ns |   1.132 ns |   1.003 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1KB          |   3,908.72 ns |  13.158 ns |  12.308 ns |    2112 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 1025B        |     739.53 ns |   1.339 ns |   1.187 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 1025B        |     842.70 ns |   1.299 ns |   1.014 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 1025B        |     984.21 ns |   0.916 ns |   0.812 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 1025B        |   4,451.15 ns |   9.199 ns |   8.604 ns |    2120 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 8KB          |   5,197.21 ns |   3.975 ns |   3.718 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 8KB          |   5,948.49 ns |   6.674 ns |   5.917 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 8KB          |   6,848.70 ns |   4.591 ns |   4.070 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 8KB          |  30,223.19 ns |  40.514 ns |  37.897 ns |    9280 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Blake2Fast) | 128KB        |  83,054.29 ns |  90.841 ns |  75.856 ns |         - |
| TryComputeHash · BLAKE2b-512 · Managed                  | 128KB        |  95,150.61 ns |  83.629 ns |  74.135 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle             | 128KB        | 109,025.38 ns | 414.316 ns | 323.471 ns |         - |
| TryComputeHash · BLAKE2b-512 · BLAKE2b-512 (Konscious)  | 128KB        | 487,768.87 ns | 868.891 ns | 770.249 ns |  132188 B |