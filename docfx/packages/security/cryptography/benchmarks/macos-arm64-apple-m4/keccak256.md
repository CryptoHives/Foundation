| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · Managed      | 128B         |     174.3 ns |   0.33 ns |   0.27 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle | 128B         |     177.5 ns |   0.43 ns |   0.36 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 137B         |     323.8 ns |   1.42 ns |   1.26 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 137B         |     536.2 ns |   8.60 ns |   8.05 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 1KB          |   1,258.5 ns |   1.17 ns |   1.04 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 1KB          |   1,373.1 ns |   6.88 ns |   6.44 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 1025B        |   1,270.2 ns |  11.39 ns |  10.65 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 1025B        |   1,380.4 ns |   4.54 ns |   4.25 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 8KB          |   9,453.5 ns |  66.12 ns |  61.85 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 8KB          |   9,864.7 ns |   9.46 ns |   7.90 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle | 128KB        | 148,905.0 ns | 576.05 ns | 449.74 ns |         - |
| TryComputeHash · Keccak-256 · Managed      | 128KB        | 153,314.5 ns | 124.84 ns | 104.24 ns |         - |