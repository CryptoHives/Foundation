| Description                            | TestDataSize | Mean            | Error         | StdDev        | Allocated |
|--------------------------------------- |------------- |----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE3 · Native       | 128B         |        98.81 ns |      0.719 ns |      0.600 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128B         |       139.20 ns |      0.569 ns |      0.475 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128B         |       551.47 ns |      5.422 ns |      4.806 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128B         |     1,314.20 ns |     24.402 ns |     21.632 ns |         - |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 137B         |       151.42 ns |      1.009 ns |      0.842 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 137B         |       219.47 ns |      3.108 ns |      2.907 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 137B         |       825.26 ns |      6.389 ns |      5.335 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 137B         |     1,940.56 ns |      3.500 ns |      3.274 ns |         - |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 1KB          |       748.31 ns |      1.951 ns |      1.729 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1KB          |     1,085.16 ns |     14.151 ns |     11.816 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1KB          |     4,200.94 ns |     19.038 ns |     16.877 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1KB          |     9,518.08 ns |     60.288 ns |     56.394 ns |         - |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 1025B        |       851.02 ns |      3.243 ns |      2.875 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1025B        |     1,242.36 ns |      6.202 ns |      5.179 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1025B        |     4,749.47 ns |     27.098 ns |     25.348 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1025B        |    10,973.20 ns |     77.121 ns |     72.139 ns |      56 B |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 8KB          |     1,185.75 ns |      4.694 ns |      4.162 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 8KB          |     9,855.63 ns |     50.941 ns |     42.538 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 8KB          |    35,446.52 ns |    172.789 ns |    161.627 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 8KB          |    80,231.04 ns |    490.246 ns |    458.576 ns |     392 B |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 128KB        |    16,884.46 ns |    156.944 ns |    146.806 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128KB        |   164,448.76 ns |    707.056 ns |    661.381 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128KB        |   571,607.17 ns |  2,301.243 ns |  2,152.584 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128KB        | 1,262,952.30 ns | 12,870.460 ns | 11,409.327 ns |    7112 B |