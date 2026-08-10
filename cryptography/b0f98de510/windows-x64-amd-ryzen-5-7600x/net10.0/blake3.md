| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE3 · Native       | 128B         |       102.0 ns |     1.26 ns |     1.18 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128B         |       139.2 ns |     1.02 ns |     0.80 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128B         |       544.9 ns |     2.91 ns |     2.58 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128B         |     1,281.8 ns |     4.57 ns |     3.81 ns |         - |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 137B         |       150.5 ns |     0.50 ns |     0.45 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 137B         |       219.7 ns |     0.82 ns |     0.69 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 137B         |       809.0 ns |     5.11 ns |     4.78 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 137B         |     1,931.4 ns |    11.57 ns |    10.26 ns |         - |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 1KB          |       752.6 ns |     2.93 ns |     2.74 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1KB          |     1,072.3 ns |     6.08 ns |     5.69 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1KB          |     4,208.7 ns |    30.55 ns |    28.58 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1KB          |     9,562.7 ns |    57.00 ns |    53.32 ns |         - |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 1025B        |       851.5 ns |     5.75 ns |     5.09 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1025B        |     1,253.4 ns |     8.02 ns |     7.11 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1025B        |     4,786.0 ns |    26.97 ns |    25.23 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1025B        |    10,539.6 ns |    34.73 ns |    30.79 ns |      56 B |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 8KB          |     1,167.7 ns |     6.08 ns |     5.39 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 8KB          |     9,980.0 ns |    77.72 ns |    68.90 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 8KB          |    35,393.1 ns |   183.03 ns |   162.25 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 8KB          |    79,942.8 ns |   179.65 ns |   150.02 ns |     392 B |
|                                        |              |                |             |             |           |
| TryComputeHash · BLAKE3 · Native       | 128KB        |    14,340.5 ns |    81.80 ns |    76.51 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128KB        |   166,364.6 ns |   628.49 ns |   587.89 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128KB        |   577,257.7 ns | 2,200.13 ns | 2,058.00 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128KB        | 1,277,034.7 ns | 9,406.64 ns | 7,854.97 ns |    7112 B |