| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · BouncyCastle | 128B         |     178.5 ns |     0.72 ns |     0.67 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 128B         |     248.4 ns |     4.90 ns |     4.81 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 137B         |     326.8 ns |     0.95 ns |     0.89 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 137B         |     603.5 ns |     6.85 ns |     6.08 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1KB          |   1,262.7 ns |     5.02 ns |     4.45 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 1KB          |   1,445.2 ns |     4.30 ns |     4.02 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1025B        |   1,261.1 ns |     2.73 ns |     2.42 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 1025B        |   1,442.9 ns |     4.16 ns |     3.89 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 8KB          |   9,447.9 ns |    25.62 ns |    22.72 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 8KB          |   9,959.1 ns |    13.70 ns |    11.44 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128KB        | 149,738.5 ns | 1,420.13 ns | 1,258.91 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 128KB        | 153,443.9 ns |   109.56 ns |    91.48 ns |         - |