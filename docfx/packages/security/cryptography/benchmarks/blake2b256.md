| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 128B         |      99.68 ns |     0.426 ns |     0.399 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 128B         |     108.15 ns |     0.680 ns |     0.636 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 128B         |     370.75 ns |     1.921 ns |     1.797 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 137B         |     191.35 ns |     1.249 ns |     1.168 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 137B         |     208.02 ns |     1.163 ns |     1.031 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 137B         |     742.19 ns |     4.598 ns |     4.301 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 1KB          |     714.33 ns |     2.505 ns |     2.343 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 1KB          |     793.84 ns |     8.467 ns |     7.506 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 1KB          |   2,864.53 ns |    21.640 ns |    20.242 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 1025B        |     796.98 ns |     2.879 ns |     2.693 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 1025B        |     892.48 ns |     4.516 ns |     3.771 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 1025B        |   3,199.35 ns |    24.045 ns |    22.492 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 8KB          |   5,577.11 ns |    17.598 ns |    13.740 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 8KB          |   6,400.82 ns |   106.419 ns |    99.545 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 8KB          |  22,683.58 ns |   107.107 ns |    94.947 ns |         - |
|                                             |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · BouncyCastle | 128KB        |  89,501.24 ns |   615.703 ns |   575.929 ns |         - |
| TryComputeHash · BLAKE2b-256 · AVX2         | 128KB        | 102,333.82 ns | 1,952.205 ns | 2,088.838 ns |         - |
| TryComputeHash · BLAKE2b-256 · Managed      | 128KB        | 362,904.58 ns | 1,642.278 ns | 1,455.837 ns |         - |