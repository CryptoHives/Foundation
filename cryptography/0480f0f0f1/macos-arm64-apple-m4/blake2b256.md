| Description                                             | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128B         |      91.35 ns |   0.149 ns |   0.132 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128B         |     101.47 ns |   0.328 ns |   0.291 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128B         |     127.44 ns |   0.209 ns |   0.196 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128B         |     606.90 ns |   1.204 ns |   1.067 ns |    1120 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 137B         |     170.83 ns |   0.185 ns |   0.144 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 137B         |     191.93 ns |   0.236 ns |   0.221 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 137B         |     233.62 ns |   0.295 ns |   0.276 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 137B         |   1,127.90 ns |   2.557 ns |   2.392 ns |    1136 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1KB          |     654.86 ns |   0.264 ns |   0.220 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1KB          |     749.41 ns |   5.204 ns |   4.345 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1KB          |     876.42 ns |   2.203 ns |   1.720 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1KB          |   3,898.12 ns |   6.467 ns |   5.733 ns |    2016 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 1025B        |     736.09 ns |   1.758 ns |   1.372 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 1025B        |     841.12 ns |   1.345 ns |   1.123 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 1025B        |     981.16 ns |   2.586 ns |   2.292 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 1025B        |   4,434.21 ns |  10.701 ns |   9.486 ns |    2024 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 8KB          |   5,184.93 ns |   2.994 ns |   2.337 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 8KB          |   5,933.50 ns |   2.825 ns |   2.359 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 8KB          |   6,834.26 ns |   3.791 ns |   2.960 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 8KB          |  30,126.48 ns |  65.990 ns |  51.520 ns |    9184 B |
|                                                         |              |               |            |            |           |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Blake2Fast) | 128KB        |  83,035.25 ns |  50.312 ns |  39.280 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed                  | 128KB        |  94,969.22 ns |  70.839 ns |  59.154 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle             | 128KB        | 109,170.07 ns |  84.487 ns |  74.896 ns |         - |
| TryComputeHash · BLAKE2b-256 · BLAKE2b-256 (Konscious)  | 128KB        | 486,165.40 ns | 776.979 ns | 688.772 ns |  132092 B |