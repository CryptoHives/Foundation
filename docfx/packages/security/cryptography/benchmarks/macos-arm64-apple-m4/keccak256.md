| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · Managed      | 128B         |     175.5 ns |   0.21 ns |   0.18 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128B         |     177.5 ns |   0.64 ns |   0.60 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 137B         |     323.2 ns |   0.68 ns |   0.57 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 137B         |     507.0 ns |  10.15 ns |  20.50 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 1KB          |   1,261.4 ns |   3.47 ns |   3.08 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 1KB          |   1,370.4 ns |   5.57 ns |   5.21 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 1025B        |   1,263.1 ns |   5.63 ns |   4.70 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 1025B        |   1,370.9 ns |   6.46 ns |   6.05 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 8KB          |   9,428.5 ns |  44.11 ns |  36.83 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 8KB          |   9,881.5 ns |  17.67 ns |  16.53 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 128KB        | 149,163.1 ns | 593.91 ns | 495.94 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 128KB        | 153,581.2 ns |  97.72 ns |  81.60 ns |         - |