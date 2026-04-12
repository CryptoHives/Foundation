| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     197.7 ns |     0.22 ns |     0.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 128B         |     351.7 ns |     0.04 ns |     0.04 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 128B         |     637.7 ns |     2.19 ns |     2.05 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     286.7 ns |     0.56 ns |     0.52 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 137B         |     529.3 ns |     0.75 ns |     0.70 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 137B         |     953.3 ns |     4.40 ns |     3.90 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,455.2 ns |     1.50 ns |     1.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 1KB          |   2,783.5 ns |     0.48 ns |     0.45 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 1KB          |   5,048.3 ns |    14.27 ns |    13.35 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,543.3 ns |     2.55 ns |     2.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 1025B        |   2,955.0 ns |     0.86 ns |     0.81 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 1025B        |   5,367.0 ns |    14.22 ns |    13.30 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,483.0 ns |    10.49 ns |     9.81 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 8KB          |  22,201.2 ns |     4.84 ns |     4.53 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 8KB          |  40,327.0 ns |   171.24 ns |   160.18 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 183,284.4 ns |   253.23 ns |   236.87 ns |         - |
| TryComputeHash · BLAKE2s-256 · BLAKE2s-256 (Neon) | 128KB        | 355,158.4 ns |    71.44 ns |    63.33 ns |         - |
| TryComputeHash · BLAKE2s-256 · Managed            | 128KB        | 645,148.0 ns | 2,217.39 ns | 2,074.15 ns |         - |