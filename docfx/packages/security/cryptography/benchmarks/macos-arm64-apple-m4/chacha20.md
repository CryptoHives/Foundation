| Description                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (Neon)         | 128B         |     169.9 ns |     0.06 ns |     0.05 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     308.8 ns |     2.73 ns |     2.56 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     521.3 ns |     0.08 ns |     0.07 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     701.5 ns |     1.55 ns |     1.37 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 128B         |     170.0 ns |     0.07 ns |     0.07 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     308.7 ns |     5.05 ns |     4.72 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     521.3 ns |     0.10 ns |     0.09 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     701.6 ns |     3.14 ns |     2.94 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (Neon)         | 1KB          |   1,338.0 ns |     0.43 ns |     0.38 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,831.0 ns |    35.63 ns |    38.12 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   2,936.3 ns |     0.54 ns |     0.42 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   5,539.4 ns |    15.93 ns |    14.12 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 1KB          |   1,337.9 ns |     0.35 ns |     0.33 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,779.7 ns |    25.56 ns |    23.91 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   2,936.4 ns |     0.50 ns |     0.44 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   5,543.8 ns |    17.46 ns |    16.33 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (Neon)         | 8KB          |  10,670.8 ns |     2.97 ns |     2.78 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,702.1 ns |   258.35 ns |   253.73 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  22,261.1 ns |    10.81 ns |    10.11 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  44,205.7 ns |   146.32 ns |   136.87 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 8KB          |  10,672.3 ns |     5.17 ns |     4.84 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,464.2 ns |   115.14 ns |   107.70 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  22,254.0 ns |     4.07 ns |     3.61 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  44,209.5 ns |   164.87 ns |   154.22 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (Neon)         | 128KB        | 170,632.9 ns |    39.45 ns |    32.94 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 212,724.8 ns |   119.16 ns |   105.63 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 353,488.8 ns |    54.73 ns |    51.20 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 707,475.1 ns | 2,908.67 ns | 2,720.77 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 128KB        | 170,653.9 ns |    66.18 ns |    58.67 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 213,050.2 ns |   185.46 ns |   173.48 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 353,449.6 ns |   110.55 ns |   103.41 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 707,643.4 ns | 2,380.75 ns | 2,226.95 ns |         - |