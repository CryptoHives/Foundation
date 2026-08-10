| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · BouncyCastle | 128B         |     324.3 ns |     0.81 ns |     0.68 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 128B         |     442.3 ns |     4.98 ns |     4.66 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 137B         |     322.7 ns |     1.08 ns |     0.96 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 137B         |     432.9 ns |     4.32 ns |     4.04 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 1KB          |   1,553.2 ns |     2.35 ns |     2.09 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 1KB          |   1,620.2 ns |     1.50 ns |     1.33 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 1025B        |   1,563.9 ns |     6.69 ns |     5.93 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 1025B        |   1,623.0 ns |     2.57 ns |     2.40 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 8KB          |  12,060.6 ns |    30.97 ns |    27.45 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 8KB          |  12,493.3 ns |    13.97 ns |    11.67 ns |         - |
|                                            |              |              |             |             |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 128KB        | 194,692.5 ns | 1,329.12 ns | 1,243.26 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 128KB        | 199,130.7 ns |   137.18 ns |   121.60 ns |         - |