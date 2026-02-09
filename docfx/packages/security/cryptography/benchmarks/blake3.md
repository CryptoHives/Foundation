| Description                            | TestDataSize | Mean            | Error         | StdDev        | Allocated |
|--------------------------------------- |------------- |----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE3 · Native       | 128B         |        99.79 ns |      1.112 ns |      0.868 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128B         |       379.11 ns |      7.604 ns |      9.051 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128B         |       584.88 ns |     11.454 ns |     16.789 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128B         |     1,334.07 ns |     25.219 ns |     23.590 ns |         - |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 137B         |       150.95 ns |      1.716 ns |      1.433 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 137B         |       441.05 ns |      8.458 ns |     10.697 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 137B         |       852.27 ns |     16.735 ns |     16.436 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 137B         |     1,965.43 ns |     37.173 ns |     39.774 ns |         - |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 1KB          |       755.42 ns |      8.744 ns |      7.751 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1KB          |     1,311.29 ns |     25.746 ns |     27.548 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1KB          |     4,333.70 ns |     72.239 ns |     60.323 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1KB          |     9,584.57 ns |    182.460 ns |    195.230 ns |         - |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 1025B        |       860.81 ns |     12.394 ns |     11.593 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 1025B        |     1,469.12 ns |     28.477 ns |     25.244 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 1025B        |     4,932.61 ns |     98.400 ns |    124.445 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 1025B        |    11,098.59 ns |    174.493 ns |    163.221 ns |      56 B |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 8KB          |     1,176.63 ns |      8.662 ns |      7.233 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 8KB          |    10,523.20 ns |    205.128 ns |    219.484 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 8KB          |    36,938.11 ns |    737.981 ns |    849.860 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 8KB          |    82,697.85 ns |  1,404.112 ns |  1,313.408 ns |     392 B |
|                                        |              |                 |               |               |           |
| TryComputeHash · BLAKE3 · Native       | 128KB        |    14,497.73 ns |    274.336 ns |    256.614 ns |         - |
| TryComputeHash · BLAKE3 · Ssse3        | 128KB        |   172,362.88 ns |  3,298.001 ns |  3,239.078 ns |         - |
| TryComputeHash · BLAKE3 · Managed      | 128KB        |   588,453.37 ns |  9,500.941 ns | 10,941.298 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle | 128KB        | 1,352,162.81 ns | 22,567.347 ns | 21,109.511 ns |    7112 B |