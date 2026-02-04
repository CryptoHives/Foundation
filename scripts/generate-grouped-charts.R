# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# generate-grouped-charts.R
# Generates grouped bar charts for BenchmarkDotNet results
# Usage: Rscript generate-grouped-charts.R <report.md> [output.png]

library(ggplot2)

# Parse command line arguments
args <- commandArgs(trailingOnly = TRUE)
if (length(args) < 1) {
  stop("Usage: Rscript generate-grouped-charts.R <report.md> [output.png]")
}

md_file <- args[1]
output_file <- if (length(args) >= 2) args[2] else gsub("\\.md$", "-grouped.png", md_file)

cat(sprintf("Reading markdown from: %s\n", md_file))

# Read markdown file
lines <- readLines(md_file, warn = FALSE)

# Find table start (header separator line with |---|---|)
table_start <- which(grepl("^\\|[-: ]+\\|", lines))[1]
if (is.na(table_start)) {
  stop("No markdown table found in file")
}

# Read table data (lines after header separator)
table_lines <- lines[(table_start + 1):length(lines)]
table_lines <- table_lines[grepl("^\\|", table_lines)]
table_lines <- table_lines[!grepl("^\\|[-:]+\\|", table_lines)]  # Remove any separators
table_lines <- table_lines[nchar(trimws(table_lines)) > 5]  # Remove empty lines

if (length(table_lines) == 0) {
  stop("No data rows found in markdown table")
}

# Parse table rows
parse_row <- function(line) {
  # Remove leading/trailing pipes and split
  cells <- strsplit(gsub("^\\|(.*)\\|$", "\\1", line), "\\|")[[1]]
  cells <- trimws(cells)
  return(cells)
}

# Parse all rows
rows <- lapply(table_lines, parse_row)

# Create data frame (assume columns: Description, TestDataSize, Mean, Error, StdDev, Allocated)
# Get header from the line before separator
header_line <- lines[table_start - 1]
headers <- parse_row(header_line)

# Build data frame
df <- as.data.frame(do.call(rbind, rows), stringsAsFactors = FALSE)
colnames(df) <- headers[1:ncol(df)]

# Clean up column names
colnames(df) <- trimws(colnames(df))

# Filter out empty rows (separator rows in markdown tables)
df <- df[nchar(trimws(df$Description)) > 0, ]

cat(sprintf("Parsed %d rows with columns: %s\n", nrow(df), paste(colnames(df), collapse = ", ")))

# Extract implementation from Description
# Format 1: "ComputeHash · SHA-256 · OS Native" (third segment after ·)
# Format 2: "Kmac128_CryptoHives" (underscore-separated, last part is implementation)
df$Implementation <- sapply(df$Description, function(desc) {
  # Check if it's the middle-dot format
  if (grepl("·", desc, fixed = TRUE)) {
    # Split by middle dot and take the last segment
    parts <- strsplit(desc, "·", fixed = TRUE)[[1]]
    impl <- trimws(parts[length(parts)])
  } else if (grepl("_", desc, fixed = TRUE)) {
    # Split by underscore and take the last segment
    parts <- strsplit(desc, "_", fixed = TRUE)[[1]]
    impl <- parts[length(parts)]
  } else {
    impl <- desc
  }

  # Map to standard names
  if (impl == "OS Native" || impl == "OS" || impl == "DotNet") {
    return("OS Native")
  } else if (impl == "Managed" || impl == "CryptoHives") {
    return("CryptoHives")
  } else if (impl == "BouncyCastle") {
    return("BouncyCastle")
  } else if (impl == "OpenGost") {
    return("OpenGost")
  } else if (impl == "Hashify .NET" || impl == "HashifyNET") {
    return("HashifyNET")
  } else if (impl %in% c("AVX2", "AVX512F", "Sse2", "Ssse3")) {
    return(paste("CryptoHives", impl))
  } else if (impl == "Native") {
    return("Native")
  } else {
    return(impl)  # Return as-is for unknown implementations
  }
})

# Get TestDataSize column (might be named differently)
size_col <- grep("TestDataSize|DataSize|Size", colnames(df), ignore.case = TRUE, value = TRUE)[1]
if (!is.na(size_col)) {
  df$DataSize <- df[[size_col]]
} else {
  df$DataSize <- "Unknown"
}

# Parse Mean column - handle format like "129.3 ns", "2.69 μs", etc.
# Convert everything to nanoseconds to avoid negative log values for sub-microsecond times
mean_col <- grep("^Mean$", colnames(df), value = TRUE)[1]
if (!is.na(mean_col)) {
  parse_mean <- function(val) {
    val <- trimws(val)
    # Extract number and unit
    number <- as.numeric(gsub("[^0-9.,]", "", gsub(",", "", val)))

    if (grepl("ns", val, fixed = TRUE)) {
      return(number)  # Already in ns
    } else if (grepl("ms", val, fixed = TRUE)) {
      return(number * 1000000)  # Convert ms to ns
    } else if (grepl("μs", val, fixed = TRUE) || grepl("us", val, fixed = TRUE)) {
      return(number * 1000)  # Convert μs to ns
    } else {
      return(number * 1000)  # Assume μs, convert to ns
    }
  }

  df$MeanNanoseconds <- sapply(df[[mean_col]], parse_mean)
} else {
  stop("Could not find Mean column")
}

# Filter valid data
df <- df[!is.na(df$MeanNanoseconds) & df$MeanNanoseconds > 0, ]
df <- df[df$Implementation != "Unknown", ]

if (nrow(df) == 0) {
  stop("No valid data after filtering")
}

# Order data size naturally
size_order <- c("128B", "137B", "1KB", "1025B", "8KB", "128KB", "1MB", "16MB")
df$DataSize <- factor(df$DataSize,
                     levels = intersect(size_order, unique(df$DataSize)))

# Order implementations - put fastest/native first, then managed, then third-party
impl_order <- c("OS Native", "Native", "CryptoHives", "CryptoHives AVX2", "CryptoHives AVX512F",
                "CryptoHives Sse2", "CryptoHives Ssse3", "BouncyCastle", "OpenGost", "HashifyNET")
# Keep only implementations that exist in data
impl_order <- intersect(impl_order, unique(df$Implementation))
# Add any remaining implementations not in the order list
remaining <- setdiff(unique(df$Implementation), impl_order)
impl_order <- c(impl_order, remaining)

df$Implementation <- factor(df$Implementation, levels = impl_order)

cat(sprintf("Generating chart with %d data points\n", nrow(df)))
cat(sprintf("Data sizes: %s\n", paste(unique(df$DataSize), collapse = ", ")))
cat(sprintf("Implementations: %s\n", paste(unique(df$Implementation), collapse = ", ")))

# Create grouped bar chart
p <- ggplot(df, aes(x = DataSize, y = MeanNanoseconds, fill = Implementation)) +
  geom_bar(stat = "identity", position = position_dodge(width = 0.9), width = 0.8) +

  # Use logarithmic scale for Y-axis to make small values visible
  scale_y_log10(
    breaks = scales::trans_breaks("log10", function(x) 10^x),
    labels = scales::trans_format("log10", scales::math_format(10^.x))
  ) +
  
  # Color scheme - extended for all implementations
  scale_fill_manual(
    values = c(
      "OS Native" = "#4CAF50",      # Green
      "Native" = "#66BB6A",          # Light green
      "CryptoHives" = "#2196F3",     # Blue
      "CryptoHives AVX2" = "#1976D2", # Darker blue
      "CryptoHives AVX512F" = "#0D47A1", # Even darker blue
      "CryptoHives Sse2" = "#42A5F5", # Light blue
      "CryptoHives Ssse3" = "#64B5F6", # Lighter blue
      "BouncyCastle" = "#FF9800",    # Orange
      "OpenGost" = "#E65100",        # Dark orange
      "HashifyNET" = "#673AB7"       # Deep purple
    ),
    drop = FALSE
  ) +
  
  # Labels and theme
  labs(
    title = "Performance Comparison by Data Size",
    subtitle = "Grouped by implementation - Lower is better (logarithmic scale)",
    x = "Input Data Size",
    y = "Mean Time (ns, log scale)",
    fill = "Implementation"
  ) +
  
  theme_minimal(base_size = 14) +
  theme(
    plot.title = element_text(hjust = 0.5, face = "bold", size = 18),
    plot.subtitle = element_text(hjust = 0.5, color = "gray50", size = 12),
    axis.text.x = element_text(angle = 45, hjust = 1, size = 12),
    axis.text.y = element_text(size = 11),
    axis.title = element_text(size = 13, face = "bold"),
    legend.position = "bottom",
    legend.title = element_text(face = "bold", size = 12),
    legend.text = element_text(size = 11),
    panel.grid.major.x = element_blank(),
    panel.grid.minor.y = element_line(color = "gray90", linewidth = 0.3),
    panel.border = element_rect(color = "gray80", fill = NA, linewidth = 0.5)
  )

# Save plot
cat(sprintf("Saving chart to: %s\n", output_file))
ggsave(output_file, plot = p, width = 14, height = 8, dpi = 300, bg = "white")

cat(sprintf("✓ Chart generated successfully!\n"))
