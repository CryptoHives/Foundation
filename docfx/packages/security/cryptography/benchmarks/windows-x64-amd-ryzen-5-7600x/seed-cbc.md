| Description                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (Managed)      | 128B         |     1.198 μs | 0.0043 μs | 0.0038 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128B         |     1.293 μs | 0.0050 μs | 0.0047 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 128B         |     1.215 μs | 0.0121 μs | 0.0113 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 128B         |     1.294 μs | 0.0041 μs | 0.0038 μs |     152 B |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 1KB          |     8.562 μs | 0.0207 μs | 0.0183 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 1KB          |     8.788 μs | 0.0269 μs | 0.0239 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 1KB          |     8.646 μs | 0.0202 μs | 0.0189 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 1KB          |     8.844 μs | 0.0254 μs | 0.0225 μs |     152 B |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 8KB          |    67.443 μs | 0.1916 μs | 0.1792 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 8KB          |    68.622 μs | 0.1889 μs | 0.1767 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 8KB          |    68.410 μs | 0.4197 μs | 0.3926 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 8KB          |    69.088 μs | 0.1708 μs | 0.1514 μs |     152 B |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 128KB        | 1,078.606 μs | 3.6863 μs | 3.2678 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,097.185 μs | 5.0076 μs | 4.6841 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 128KB        | 1,093.699 μs | 3.7858 μs | 3.5412 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,104.333 μs | 2.6994 μs | 2.3929 μs |     152 B |